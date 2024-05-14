namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateProgramApplicantCustomQuestionResponseTests : TestBase
{
    [Fact]
    public async Task create_programapplicantcustomquestionresponse_returns_created_using_valid_dto()
    {
        // Arrange
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseForCreationDto().Generate();

        // Act
        var route = ApiRoutes.ProgramApplicantCustomQuestionResponses.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, programApplicantCustomQuestionResponse);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}