namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramApplicantPersonalInformationTests : TestBase
{
    [Fact]
    public async Task get_programapplicantpersonalinformation_returns_success_when_entity_exists()
    {
        // Arrange
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        await InsertAsync(programApplicantPersonalInformation);

        // Act
        var route = ApiRoutes.ProgramApplicantPersonalInformations.GetRecord(programApplicantPersonalInformation.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}