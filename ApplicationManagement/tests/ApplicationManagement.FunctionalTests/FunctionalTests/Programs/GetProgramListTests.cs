namespace ApplicationManagement.FunctionalTests.FunctionalTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramListTests : TestBase
{
    [Fact]
    public async Task get_program_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Programs.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}