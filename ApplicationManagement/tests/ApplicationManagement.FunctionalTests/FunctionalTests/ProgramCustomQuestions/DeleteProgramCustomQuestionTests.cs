namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteProgramCustomQuestionTests : TestBase
{
    [Fact]
    public async Task delete_programcustomquestion_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        await InsertAsync(programCustomQuestion);

        // Act
        var route = ApiRoutes.ProgramCustomQuestions.Delete(programCustomQuestion.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}