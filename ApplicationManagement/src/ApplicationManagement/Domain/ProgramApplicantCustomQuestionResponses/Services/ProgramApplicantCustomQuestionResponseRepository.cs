namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Services;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IProgramApplicantCustomQuestionResponseRepository : IGenericRepository<ProgramApplicantCustomQuestionResponse>
{
}

public sealed class ProgramApplicantCustomQuestionResponseRepository(ApplicationDbContext dbContext) : GenericRepository<ProgramApplicantCustomQuestionResponse>(dbContext), IProgramApplicantCustomQuestionResponseRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
