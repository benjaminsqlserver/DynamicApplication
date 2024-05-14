namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramCustomQuestionTests : TestBase
{
    [Fact]
    public async Task get_programcustomquestion_returns_success_when_entity_exists()
    {
        // Arrange
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        await InsertAsync(programCustomQuestion);

        // Act
        var route = ApiRoutes.ProgramCustomQuestions.GetRecord(programCustomQuestion.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}