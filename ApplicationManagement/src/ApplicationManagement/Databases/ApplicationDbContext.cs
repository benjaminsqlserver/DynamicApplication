namespace ApplicationManagement.Databases;

using ApplicationManagement.Domain;
using ApplicationManagement.Databases.EntityConfigurations;
using ApplicationManagement.Services;
using Configurations;
using MediatR;
using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.QuestionTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Driver;

public sealed class ApplicationDbContext : DbContext
{
    private readonly IMongoDatabase _mongoDatabase;

    #region DbSet Region - Do Not Delete
    public IMongoCollection<DropdownChoiceQuestion> DropdownChoiceQuestions { get; private set; }
    public IMongoCollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; private set; }
    public IMongoCollection<ProgramApplicantCustomQuestionResponse> ProgramApplicantCustomQuestionResponses { get; private set; }
    public IMongoCollection<ProgramApplicantPersonalInformation> ProgramApplicantPersonalInformations { get; private set; }
    public IMongoCollection<ProgramCustomQuestion> ProgramCustomQuestions { get; private set; }
    public IMongoCollection<Program> Programs { get; private set; }
    public IMongoCollection<QuestionType> QuestionTypes { get; private set; }
    #endregion DbSet Region - Do Not Delete

    private readonly ICurrentUserService _currentUserService;
    private readonly IMediator _mediator;
    private readonly TimeProvider _dateTimeProvider;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService,
        IMediator mediator,
        TimeProvider dateTimeProvider,
        IConfiguration configuration)
        : base(options)
    {
        _currentUserService = currentUserService;
        _mediator = mediator;
        _dateTimeProvider = dateTimeProvider;

        // Initialize MongoDB client and database
        var mongoClient = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        _mongoDatabase = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        // Initialize MongoDB collections
        DropdownChoiceQuestions = _mongoDatabase.GetCollection<DropdownChoiceQuestion>(
            configuration.GetValue<string>("DatabaseSettings:DropdownChoiceQuestionsCollection"));
        MultipleChoiceQuestions = _mongoDatabase.GetCollection<MultipleChoiceQuestion>(
            configuration.GetValue<string>("DatabaseSettings:MultipleChoiceQuestionsCollection"));
        ProgramApplicantCustomQuestionResponses = _mongoDatabase.GetCollection<ProgramApplicantCustomQuestionResponse>(
            configuration.GetValue<string>("DatabaseSettings:ProgramApplicantCustomQuestionResponsesCollection"));
        ProgramApplicantPersonalInformations = _mongoDatabase.GetCollection<ProgramApplicantPersonalInformation>(
            configuration.GetValue<string>("DatabaseSettings:ProgramApplicantPersonalInformationsCollection"));
        ProgramCustomQuestions = _mongoDatabase.GetCollection<ProgramCustomQuestion>(
            configuration.GetValue<string>("DatabaseSettings:ProgramCustomQuestionsCollection"));
        Programs = _mongoDatabase.GetCollection<Program>(
            configuration.GetValue<string>("DatabaseSettings:ProgramsCollection"));
        QuestionTypes = _mongoDatabase.GetCollection<QuestionType>(
            configuration.GetValue<string>("DatabaseSettings:QuestionTypesCollection"));

        // Optionally, seed data
        // SeedData();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.FilterSoftDeletedRecords();
        /* any query filters added after this will override soft delete 
                https://docs.microsoft.com/en-us/ef/core/querying/filters
                https://github.com/dotnet/efcore/issues/10275
        */

        #region Entity Database Config Region - Only delete if you don't want to automatically add configurations
        modelBuilder.ApplyConfiguration(new DropdownChoiceQuestionConfiguration());
        modelBuilder.ApplyConfiguration(new MultipleChoiceQuestionConfiguration());
        modelBuilder.ApplyConfiguration(new ProgramApplicantCustomQuestionResponseConfiguration());
        modelBuilder.ApplyConfiguration(new ProgramApplicantPersonalInformationConfiguration());
        modelBuilder.ApplyConfiguration(new ProgramCustomQuestionConfiguration());
        modelBuilder.ApplyConfiguration(new ProgramConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionTypeConfiguration());
        #endregion Entity Database Config Region - Only delete if you don't want to automatically add configurations
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        var result = base.SaveChanges();
        _dispatchDomainEvents().GetAwaiter().GetResult();
        return result;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateAuditFields();
        var result = await base.SaveChangesAsync(cancellationToken);
        await _dispatchDomainEvents();
        return result;
    }

    private async Task _dispatchDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<BaseEntity>()
            .Select(po => po.Entity)
            .Where(po => po.DomainEvents.Any())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            var events = entity.DomainEvents.ToArray();
            entity.DomainEvents.Clear();
            foreach (var entityDomainEvent in events)
                await _mediator.Publish(entityDomainEvent);
        }
    }

    private void UpdateAuditFields()
    {
        var now = _dateTimeProvider.GetUtcNow();
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.UpdateCreationProperties(now, _currentUserService?.UserId);
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService?.UserId);
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService?.UserId);
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService?.UserId);
                    entry.Entity.UpdateIsDeleted(true);
                    break;
            }
        }
    }
}

public static class Extensions
{
    public static void FilterSoftDeletedRecords(this ModelBuilder modelBuilder)
    {
        Expression<Func<BaseEntity, bool>> filterExpr = e => !e.IsDeleted;
        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes()
            .Where(m => m.ClrType.IsAssignableTo(typeof(BaseEntity))))
        {
            // modify expression to handle correct child type
            var parameter = Expression.Parameter(mutableEntityType.ClrType);
            var body = ReplacingExpressionVisitor
                .Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
            var lambdaExpression = Expression.Lambda(body, parameter);

            // set filter
            mutableEntityType.SetQueryFilter(lambdaExpression);
        }
    }
}
