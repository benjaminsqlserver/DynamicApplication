namespace ApplicationManagement.FunctionalTests.FunctionalTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetMultipleChoiceQuestionListTests : TestBase
{
    [Fact]
    public async Task get_multiplechoicequestion_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.MultipleChoiceQuestions.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}