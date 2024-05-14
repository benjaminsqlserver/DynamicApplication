namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateProgramApplicantPersonalInformationRecordTests : TestBase
{
    [Fact]
    public async Task put_programapplicantpersonalinformation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        var updatedProgramApplicantPersonalInformationDto = new FakeProgramApplicantPersonalInformationForUpdateDto().Generate();
        await InsertAsync(programApplicantPersonalInformation);

        // Act
        var route = ApiRoutes.ProgramApplicantPersonalInformations.Put(programApplicantPersonalInformation.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedProgramApplicantPersonalInformationDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}