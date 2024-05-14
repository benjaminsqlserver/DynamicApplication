namespace ApplicationManagement.FunctionalTests.FunctionalTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateMultipleChoiceQuestionTests : TestBase
{
    [Fact]
    public async Task create_multiplechoicequestion_returns_created_using_valid_dto()
    {
        // Arrange
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionForCreationDto().Generate();

        // Act
        var route = ApiRoutes.MultipleChoiceQuestions.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, multipleChoiceQuestion);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}