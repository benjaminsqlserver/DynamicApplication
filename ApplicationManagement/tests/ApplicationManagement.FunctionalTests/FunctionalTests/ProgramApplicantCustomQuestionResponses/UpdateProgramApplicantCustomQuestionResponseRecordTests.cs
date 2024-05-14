namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateProgramApplicantCustomQuestionResponseRecordTests : TestBase
{
    [Fact]
    public async Task put_programapplicantcustomquestionresponse_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        var updatedProgramApplicantCustomQuestionResponseDto = new FakeProgramApplicantCustomQuestionResponseForUpdateDto().Generate();
        await InsertAsync(programApplicantCustomQuestionResponse);

        // Act
        var route = ApiRoutes.ProgramApplicantCustomQuestionResponses.Put(programApplicantCustomQuestionResponse.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedProgramApplicantCustomQuestionResponseDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}