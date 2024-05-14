namespace ApplicationManagement.FunctionalTests.FunctionalTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetDropdownChoiceQuestionListTests : TestBase
{
    [Fact]
    public async Task get_dropdownchoicequestion_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.DropdownChoiceQuestions.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}