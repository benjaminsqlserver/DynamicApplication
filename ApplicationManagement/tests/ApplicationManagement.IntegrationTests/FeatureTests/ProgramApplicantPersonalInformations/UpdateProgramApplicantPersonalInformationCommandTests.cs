namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateProgramApplicantPersonalInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_programapplicantpersonalinformation_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantPersonalInformation);
        var updatedProgramApplicantPersonalInformationDto = new FakeProgramApplicantPersonalInformationForUpdateDto().Generate();

        // Act
        var command = new UpdateProgramApplicantPersonalInformation.Command(programApplicantPersonalInformation.Id, updatedProgramApplicantPersonalInformationDto);
        await testingServiceScope.SendAsync(command);
        var updatedProgramApplicantPersonalInformation = await testingServiceScope
            .ExecuteDbContextAsync(db => db.ProgramApplicantPersonalInformations
                .FirstOrDefaultAsync(p => p.Id == programApplicantPersonalInformation.Id));

        // Assert
        updatedProgramApplicantPersonalInformation.FirstName.Should().Be(updatedProgramApplicantPersonalInformationDto.FirstName);
        updatedProgramApplicantPersonalInformation.LastName.Should().Be(updatedProgramApplicantPersonalInformationDto.LastName);
        updatedProgramApplicantPersonalInformation.Email.Should().Be(updatedProgramApplicantPersonalInformationDto.Email);
        updatedProgramApplicantPersonalInformation.Phone.Should().Be(updatedProgramApplicantPersonalInformationDto.Phone);
        updatedProgramApplicantPersonalInformation.Nationality.Should().Be(updatedProgramApplicantPersonalInformationDto.Nationality);
        updatedProgramApplicantPersonalInformation.CurrentResidence.Should().Be(updatedProgramApplicantPersonalInformationDto.CurrentResidence);
        updatedProgramApplicantPersonalInformation.IdNumber.Should().Be(updatedProgramApplicantPersonalInformationDto.IdNumber);
        updatedProgramApplicantPersonalInformation.Gender.Should().Be(updatedProgramApplicantPersonalInformationDto.Gender);
    }
}