namespace ApplicationManagement.FunctionalTests.FunctionalTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetDropdownChoiceQuestionTests : TestBase
{
    [Fact]
    public async Task get_dropdownchoicequestion_returns_success_when_entity_exists()
    {
        // Arrange
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        await InsertAsync(dropdownChoiceQuestion);

        // Act
        var route = ApiRoutes.DropdownChoiceQuestions.GetRecord(dropdownChoiceQuestion.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}