namespace ApplicationManagement.Domain.Programs.Services;

using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Databases;
using ApplicationManagement.Services;

public interface IProgramRepository : IGenericRepository<Program>
{
}

public sealed class ProgramRepository(ApplicationDbContext dbContext) : GenericRepository<Program>(dbContext), IProgramRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}  
