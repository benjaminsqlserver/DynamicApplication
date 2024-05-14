namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Services;

using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IDropdownChoiceQuestionRepository : IGenericRepository<DropdownChoiceQuestion>
{
}

public sealed class DropdownChoiceQuestionRepository(ApplicationDbContext dbContext) : GenericRepository<DropdownChoiceQuestion>(dbContext), IDropdownChoiceQuestionRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
