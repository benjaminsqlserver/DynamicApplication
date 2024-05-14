namespace ApplicationManagement.IntegrationTests.FeatureTests.Programs;

using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.Domain.Programs.Features;
using Domain;
using System.Threading.Tasks;

public class ProgramListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_program_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programOne = new FakeProgramBuilder().Build();
        var programTwo = new FakeProgramBuilder().Build();
        var queryParameters = new ProgramParametersDto();

        await testingServiceScope.InsertAsync(programOne, programTwo);

        // Act
        var query = new GetProgramList.Query(queryParameters);
        var programs = await testingServiceScope.SendAsync(query);

        // Assert
        programs.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}