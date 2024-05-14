namespace ApplicationManagement.FunctionalTests.FunctionalTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateProgramTests : TestBase
{
    [Fact]
    public async Task create_program_returns_created_using_valid_dto()
    {
        // Arrange
        var program = new FakeProgramForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Programs.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, program);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}