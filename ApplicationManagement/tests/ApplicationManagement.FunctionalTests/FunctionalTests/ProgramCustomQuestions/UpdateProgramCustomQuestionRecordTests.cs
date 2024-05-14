namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateProgramCustomQuestionRecordTests : TestBase
{
    [Fact]
    public async Task put_programcustomquestion_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        var updatedProgramCustomQuestionDto = new FakeProgramCustomQuestionForUpdateDto().Generate();
        await InsertAsync(programCustomQuestion);

        // Act
        var route = ApiRoutes.ProgramCustomQuestions.Put(programCustomQuestion.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedProgramCustomQuestionDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}