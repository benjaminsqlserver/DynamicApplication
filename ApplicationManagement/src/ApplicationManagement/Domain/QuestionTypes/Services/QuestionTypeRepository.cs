namespace ApplicationManagement.Domain.QuestionTypes.Services;

using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IQuestionTypeRepository : IGenericRepository<QuestionType>
{
}

public sealed class QuestionTypeRepository(ApplicationDbContext dbContext) : GenericRepository<QuestionType>(dbContext), IQuestionTypeRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
