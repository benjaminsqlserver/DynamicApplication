namespace ApplicationManagement.Domain.ProgramCustomQuestions.Services;

using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IProgramCustomQuestionRepository : IGenericRepository<ProgramCustomQuestion>
{
}

public sealed class ProgramCustomQuestionRepository(ApplicationDbContext dbContext) : GenericRepository<ProgramCustomQuestion>(dbContext), IProgramCustomQuestionRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
