namespace ApplicationManagement.Extensions.Services;

using ApplicationManagement.Databases;
using ApplicationManagement.Resources;
using ApplicationManagement.Services;
using ApplicationManagement.Resources.HangfireUtilities;
using Configurations;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
    {
        // DbContext -- Do Not Delete
        //var connectionString = configuration.GetConnectionStringOptions().ApplicationManagement;
        var connectionString = "mongodb://localhost:C2y6yDjf5%2FR%2Bob0N8A7Cgv30VRDJIWEHLM%2B4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw%2FJw%3D%3D@localhost:10255/admin?ssl=true, DatabaseName: DynamicApplicationDB, CollectionName: DynamicApplications, DropdownChoiceQuestionsCollection: DropdownChoiceQuestions, MultipleChoiceQuestionsCollection: MultipleChoiceQuestions, ProgramApplicantCustomQuestionResponsesCollection: ProgramApplicantCustomQuestionResponses, ProgramApplicantPersonalInformationsCollection: ProgramApplicantPersonalInformations, ProgramCustomQuestionsCollection: ProgramCustomQuestions, ProgramsCollection: Programs, QuestionTypesCollection: QuestionTypes";
               
        

       


        services.AddHostedService<MigrationHostedService<ApplicationDbContext>>();

        services.SetupHangfire(env);

        // Auth -- Do Not Delete
    }
}
    
public static class HangfireConfig
{
    public static void SetupHangfire(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IJobContextAccessor, JobContextAccessor>();
        services.AddScoped<IJobWithUserContext, JobWithUserContext>();
        // if you want tags with sql server
        // var tagOptions = new TagsOptions() { TagsListStyle = TagsListStyle.Dropdown };
        
        // var hangfireConfig = new MemoryStorageOptions() { };
        services.AddHangfire(config =>
        {
            config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseMemoryStorage()
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                // if you want tags with sql server
                // .UseTagsWithSql(tagOptions, hangfireConfig)
                .UseActivator(new JobWithUserContextActivator(services.BuildServiceProvider()
                    .GetRequiredService<IServiceScopeFactory>()));
        });
        services.AddHangfireServer(options =>
        {
            options.WorkerCount = 10;
            options.ServerName = $"PeakLims-{env.EnvironmentName}";

            if (Consts.HangfireQueues.List().Length > 0)
            {
                options.Queues = Consts.HangfireQueues.List();
            }
        });

    }
}
