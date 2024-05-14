namespace ApplicationManagement.FunctionalTests.FunctionalTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetQuestionTypeListTests : TestBase
{
    [Fact]
    public async Task get_questiontype_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.QuestionTypes.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}