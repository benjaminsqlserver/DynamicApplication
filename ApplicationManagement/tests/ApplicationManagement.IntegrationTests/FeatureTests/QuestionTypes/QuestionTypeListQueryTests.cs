namespace ApplicationManagement.IntegrationTests.FeatureTests.QuestionTypes;

using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.Domain.QuestionTypes.Features;
using Domain;
using System.Threading.Tasks;

public class QuestionTypeListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_questiontype_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var questionTypeOne = new FakeQuestionTypeBuilder().Build();
        var questionTypeTwo = new FakeQuestionTypeBuilder().Build();
        var queryParameters = new QuestionTypeParametersDto();

        await testingServiceScope.InsertAsync(questionTypeOne, questionTypeTwo);

        // Act
        var query = new GetQuestionTypeList.Query(queryParameters);
        var questionTypes = await testingServiceScope.SendAsync(query);

        // Assert
        questionTypes.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}