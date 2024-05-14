namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteProgramApplicantCustomQuestionResponseTests : TestBase
{
    [Fact]
    public async Task delete_programapplicantcustomquestionresponse_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        await InsertAsync(programApplicantCustomQuestionResponse);

        // Act
        var route = ApiRoutes.ProgramApplicantCustomQuestionResponses.Delete(programApplicantCustomQuestionResponse.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}