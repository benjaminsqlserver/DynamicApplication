namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteProgramApplicantPersonalInformationTests : TestBase
{
    [Fact]
    public async Task delete_programapplicantpersonalinformation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        await InsertAsync(programApplicantPersonalInformation);

        // Act
        var route = ApiRoutes.ProgramApplicantPersonalInformations.Delete(programApplicantPersonalInformation.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}