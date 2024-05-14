namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Services;

using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IMultipleChoiceQuestionRepository : IGenericRepository<MultipleChoiceQuestion>
{
}

public sealed class MultipleChoiceQuestionRepository(ApplicationDbContext dbContext) : GenericRepository<MultipleChoiceQuestion>(dbContext), IMultipleChoiceQuestionRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
