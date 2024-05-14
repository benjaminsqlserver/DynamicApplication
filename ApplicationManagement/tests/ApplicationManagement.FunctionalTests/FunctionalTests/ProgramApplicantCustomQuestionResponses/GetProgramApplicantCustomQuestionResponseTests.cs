namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramApplicantCustomQuestionResponseTests : TestBase
{
    [Fact]
    public async Task get_programapplicantcustomquestionresponse_returns_success_when_entity_exists()
    {
        // Arrange
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        await InsertAsync(programApplicantCustomQuestionResponse);

        // Act
        var route = ApiRoutes.ProgramApplicantCustomQuestionResponses.GetRecord(programApplicantCustomQuestionResponse.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}