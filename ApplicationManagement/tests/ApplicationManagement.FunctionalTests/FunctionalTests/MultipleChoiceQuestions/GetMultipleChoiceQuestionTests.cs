namespace ApplicationManagement.FunctionalTests.FunctionalTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetMultipleChoiceQuestionTests : TestBase
{
    [Fact]
    public async Task get_multiplechoicequestion_returns_success_when_entity_exists()
    {
        // Arrange
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        await InsertAsync(multipleChoiceQuestion);

        // Act
        var route = ApiRoutes.MultipleChoiceQuestions.GetRecord(multipleChoiceQuestion.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}