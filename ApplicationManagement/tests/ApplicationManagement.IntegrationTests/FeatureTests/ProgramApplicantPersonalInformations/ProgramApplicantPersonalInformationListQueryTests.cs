namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;
using Domain;
using System.Threading.Tasks;

public class ProgramApplicantPersonalInformationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_programapplicantpersonalinformation_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantPersonalInformationOne = new FakeProgramApplicantPersonalInformationBuilder().Build();
        var programApplicantPersonalInformationTwo = new FakeProgramApplicantPersonalInformationBuilder().Build();
        var queryParameters = new ProgramApplicantPersonalInformationParametersDto();

        await testingServiceScope.InsertAsync(programApplicantPersonalInformationOne, programApplicantPersonalInformationTwo);

        // Act
        var query = new GetProgramApplicantPersonalInformationList.Query(queryParameters);
        var programApplicantPersonalInformations = await testingServiceScope.SendAsync(query);

        // Assert
        programApplicantPersonalInformations.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}