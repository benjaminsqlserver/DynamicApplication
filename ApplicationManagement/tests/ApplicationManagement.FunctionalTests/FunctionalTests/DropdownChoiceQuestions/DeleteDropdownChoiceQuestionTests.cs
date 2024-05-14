namespace ApplicationManagement.FunctionalTests.FunctionalTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteDropdownChoiceQuestionTests : TestBase
{
    [Fact]
    public async Task delete_dropdownchoicequestion_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        await InsertAsync(dropdownChoiceQuestion);

        // Act
        var route = ApiRoutes.DropdownChoiceQuestions.Delete(dropdownChoiceQuestion.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}