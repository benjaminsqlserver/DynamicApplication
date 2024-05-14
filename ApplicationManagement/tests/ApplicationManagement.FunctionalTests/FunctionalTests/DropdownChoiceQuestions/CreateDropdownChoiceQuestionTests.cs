namespace ApplicationManagement.FunctionalTests.FunctionalTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateDropdownChoiceQuestionTests : TestBase
{
    [Fact]
    public async Task create_dropdownchoicequestion_returns_created_using_valid_dto()
    {
        // Arrange
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionForCreationDto().Generate();

        // Act
        var route = ApiRoutes.DropdownChoiceQuestions.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, dropdownChoiceQuestion);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}