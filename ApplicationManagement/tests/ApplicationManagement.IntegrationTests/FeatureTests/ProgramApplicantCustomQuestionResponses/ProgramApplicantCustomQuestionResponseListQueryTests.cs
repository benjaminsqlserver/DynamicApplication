namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;
using Domain;
using System.Threading.Tasks;

public class ProgramApplicantCustomQuestionResponseListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_programapplicantcustomquestionresponse_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantCustomQuestionResponseOne = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        var programApplicantCustomQuestionResponseTwo = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        var queryParameters = new ProgramApplicantCustomQuestionResponseParametersDto();

        await testingServiceScope.InsertAsync(programApplicantCustomQuestionResponseOne, programApplicantCustomQuestionResponseTwo);

        // Act
        var query = new GetProgramApplicantCustomQuestionResponseList.Query(queryParameters);
        var programApplicantCustomQuestionResponses = await testingServiceScope.SendAsync(query);

        // Assert
        programApplicantCustomQuestionResponses.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}