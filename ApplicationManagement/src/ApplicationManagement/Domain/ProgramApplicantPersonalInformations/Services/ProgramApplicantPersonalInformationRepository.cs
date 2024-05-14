namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Services;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IProgramApplicantPersonalInformationRepository : IGenericRepository<ProgramApplicantPersonalInformation>
{
}

public sealed class ProgramApplicantPersonalInformationRepository(ApplicationDbContext dbContext) : GenericRepository<ProgramApplicantPersonalInformation>(dbContext), IProgramApplicantPersonalInformationRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
