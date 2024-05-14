namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramCustomQuestions;

using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.Domain.ProgramCustomQuestions.Features;
using Domain;
using System.Threading.Tasks;

public class ProgramCustomQuestionListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_programcustomquestion_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programCustomQuestionOne = new FakeProgramCustomQuestionBuilder().Build();
        var programCustomQuestionTwo = new FakeProgramCustomQuestionBuilder().Build();
        var queryParameters = new ProgramCustomQuestionParametersDto();

        await testingServiceScope.InsertAsync(programCustomQuestionOne, programCustomQuestionTwo);

        // Act
        var query = new GetProgramCustomQuestionList.Query(queryParameters);
        var programCustomQuestions = await testingServiceScope.SendAsync(query);

        // Assert
        programCustomQuestions.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}