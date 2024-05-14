namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramApplicantCustomQuestionResponseListTests : TestBase
{
    [Fact]
    public async Task get_programapplicantcustomquestionresponse_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.ProgramApplicantCustomQuestionResponses.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}