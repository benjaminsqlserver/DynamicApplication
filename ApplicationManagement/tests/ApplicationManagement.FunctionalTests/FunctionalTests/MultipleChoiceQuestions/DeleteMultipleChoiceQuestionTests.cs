namespace ApplicationManagement.FunctionalTests.FunctionalTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteMultipleChoiceQuestionTests : TestBase
{
    [Fact]
    public async Task delete_multiplechoicequestion_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        await InsertAsync(multipleChoiceQuestion);

        // Act
        var route = ApiRoutes.MultipleChoiceQuestions.Delete(multipleChoiceQuestion.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}