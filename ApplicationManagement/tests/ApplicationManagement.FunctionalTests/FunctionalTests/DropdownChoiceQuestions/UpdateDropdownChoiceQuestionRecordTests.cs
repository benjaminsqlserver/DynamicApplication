namespace ApplicationManagement.FunctionalTests.FunctionalTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateDropdownChoiceQuestionRecordTests : TestBase
{
    [Fact]
    public async Task put_dropdownchoicequestion_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        var updatedDropdownChoiceQuestionDto = new FakeDropdownChoiceQuestionForUpdateDto().Generate();
        await InsertAsync(dropdownChoiceQuestion);

        // Act
        var route = ApiRoutes.DropdownChoiceQuestions.Put(dropdownChoiceQuestion.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedDropdownChoiceQuestionDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}