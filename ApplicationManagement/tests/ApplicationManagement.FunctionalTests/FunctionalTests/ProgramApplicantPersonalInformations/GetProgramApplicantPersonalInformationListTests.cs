namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramApplicantPersonalInformationListTests : TestBase
{
    [Fact]
    public async Task get_programapplicantpersonalinformation_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.ProgramApplicantPersonalInformations.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}