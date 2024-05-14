namespace ApplicationManagement.FunctionalTests.FunctionalTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteProgramTests : TestBase
{
    [Fact]
    public async Task delete_program_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var program = new FakeProgramBuilder().Build();
        await InsertAsync(program);

        // Act
        var route = ApiRoutes.Programs.Delete(program.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}