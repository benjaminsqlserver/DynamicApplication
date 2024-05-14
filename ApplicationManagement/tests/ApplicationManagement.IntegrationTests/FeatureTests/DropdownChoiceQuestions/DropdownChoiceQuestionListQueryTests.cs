namespace ApplicationManagement.IntegrationTests.FeatureTests.DropdownChoiceQuestions;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Features;
using Domain;
using System.Threading.Tasks;

public class DropdownChoiceQuestionListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_dropdownchoicequestion_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var dropdownChoiceQuestionOne = new FakeDropdownChoiceQuestionBuilder().Build();
        var dropdownChoiceQuestionTwo = new FakeDropdownChoiceQuestionBuilder().Build();
        var queryParameters = new DropdownChoiceQuestionParametersDto();

        await testingServiceScope.InsertAsync(dropdownChoiceQuestionOne, dropdownChoiceQuestionTwo);

        // Act
        var query = new GetDropdownChoiceQuestionList.Query(queryParameters);
        var dropdownChoiceQuestions = await testingServiceScope.SendAsync(query);

        // Assert
        dropdownChoiceQuestions.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}