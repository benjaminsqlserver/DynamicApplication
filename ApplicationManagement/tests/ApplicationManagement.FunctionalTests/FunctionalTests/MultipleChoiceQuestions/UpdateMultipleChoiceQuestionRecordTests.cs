namespace ApplicationManagement.FunctionalTests.FunctionalTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateMultipleChoiceQuestionRecordTests : TestBase
{
    [Fact]
    public async Task put_multiplechoicequestion_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        var updatedMultipleChoiceQuestionDto = new FakeMultipleChoiceQuestionForUpdateDto().Generate();
        await InsertAsync(multipleChoiceQuestion);

        // Act
        var route = ApiRoutes.MultipleChoiceQuestions.Put(multipleChoiceQuestion.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedMultipleChoiceQuestionDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}