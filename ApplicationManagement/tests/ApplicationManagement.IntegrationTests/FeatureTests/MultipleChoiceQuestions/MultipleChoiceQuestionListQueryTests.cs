namespace ApplicationManagement.IntegrationTests.FeatureTests.MultipleChoiceQuestions;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Features;
using Domain;
using System.Threading.Tasks;

public class MultipleChoiceQuestionListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_multiplechoicequestion_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var multipleChoiceQuestionOne = new FakeMultipleChoiceQuestionBuilder().Build();
        var multipleChoiceQuestionTwo = new FakeMultipleChoiceQuestionBuilder().Build();
        var queryParameters = new MultipleChoiceQuestionParametersDto();

        await testingServiceScope.InsertAsync(multipleChoiceQuestionOne, multipleChoiceQuestionTwo);

        // Act
        var query = new GetMultipleChoiceQuestionList.Query(queryParameters);
        var multipleChoiceQuestions = await testingServiceScope.SendAsync(query);

        // Assert
        multipleChoiceQuestions.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}