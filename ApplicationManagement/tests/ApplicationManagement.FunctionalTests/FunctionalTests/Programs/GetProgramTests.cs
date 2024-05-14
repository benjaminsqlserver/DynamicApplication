namespace ApplicationManagement.FunctionalTests.FunctionalTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramTests : TestBase
{
    [Fact]
    public async Task get_program_returns_success_when_entity_exists()
    {
        // Arrange
        var program = new FakeProgramBuilder().Build();
        await InsertAsync(program);

        // Act
        var route = ApiRoutes.Programs.GetRecord(program.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}