namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateProgramCustomQuestionTests : TestBase
{
    [Fact]
    public async Task create_programcustomquestion_returns_created_using_valid_dto()
    {
        // Arrange
        var programCustomQuestion = new FakeProgramCustomQuestionForCreationDto().Generate();

        // Act
        var route = ApiRoutes.ProgramCustomQuestions.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, programCustomQuestion);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}