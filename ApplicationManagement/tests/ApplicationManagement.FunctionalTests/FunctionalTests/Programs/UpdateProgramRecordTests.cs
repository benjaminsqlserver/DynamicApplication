namespace ApplicationManagement.FunctionalTests.FunctionalTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateProgramRecordTests : TestBase
{
    [Fact]
    public async Task put_program_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var program = new FakeProgramBuilder().Build();
        var updatedProgramDto = new FakeProgramForUpdateDto().Generate();
        await InsertAsync(program);

        // Act
        var route = ApiRoutes.Programs.Put(program.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedProgramDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}