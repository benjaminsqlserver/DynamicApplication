namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateProgramApplicantPersonalInformationTests : TestBase
{
    [Fact]
    public async Task create_programapplicantpersonalinformation_returns_created_using_valid_dto()
    {
        // Arrange
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationForCreationDto().Generate();

        // Act
        var route = ApiRoutes.ProgramApplicantPersonalInformations.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, programApplicantPersonalInformation);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}