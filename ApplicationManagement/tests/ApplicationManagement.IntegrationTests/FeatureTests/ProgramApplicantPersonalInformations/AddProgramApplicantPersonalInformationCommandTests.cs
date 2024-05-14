namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;

public class AddProgramApplicantPersonalInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_programapplicantpersonalinformation_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantPersonalInformationOne = new FakeProgramApplicantPersonalInformationForCreationDto().Generate();

        // Act
        var command = new AddProgramApplicantPersonalInformation.Command(programApplicantPersonalInformationOne);
        var programApplicantPersonalInformationReturned = await testingServiceScope.SendAsync(command);
        var programApplicantPersonalInformationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.ProgramApplicantPersonalInformations
            .FirstOrDefaultAsync(p => p.Id == programApplicantPersonalInformationReturned.Id));

        // Assert
        programApplicantPersonalInformationReturned.FirstName.Should().Be(programApplicantPersonalInformationOne.FirstName);
        programApplicantPersonalInformationReturned.LastName.Should().Be(programApplicantPersonalInformationOne.LastName);
        programApplicantPersonalInformationReturned.Email.Should().Be(programApplicantPersonalInformationOne.Email);
        programApplicantPersonalInformationReturned.Phone.Should().Be(programApplicantPersonalInformationOne.Phone);
        programApplicantPersonalInformationReturned.Nationality.Should().Be(programApplicantPersonalInformationOne.Nationality);
        programApplicantPersonalInformationReturned.CurrentResidence.Should().Be(programApplicantPersonalInformationOne.CurrentResidence);
        programApplicantPersonalInformationReturned.IdNumber.Should().Be(programApplicantPersonalInformationOne.IdNumber);
        programApplicantPersonalInformationReturned.Gender.Should().Be(programApplicantPersonalInformationOne.Gender);

        programApplicantPersonalInformationCreated.FirstName.Should().Be(programApplicantPersonalInformationOne.FirstName);
        programApplicantPersonalInformationCreated.LastName.Should().Be(programApplicantPersonalInformationOne.LastName);
        programApplicantPersonalInformationCreated.Email.Should().Be(programApplicantPersonalInformationOne.Email);
        programApplicantPersonalInformationCreated.Phone.Should().Be(programApplicantPersonalInformationOne.Phone);
        programApplicantPersonalInformationCreated.Nationality.Should().Be(programApplicantPersonalInformationOne.Nationality);
        programApplicantPersonalInformationCreated.CurrentResidence.Should().Be(programApplicantPersonalInformationOne.CurrentResidence);
        programApplicantPersonalInformationCreated.IdNumber.Should().Be(programApplicantPersonalInformationOne.IdNumber);
        programApplicantPersonalInformationCreated.Gender.Should().Be(programApplicantPersonalInformationOne.Gender);
    }
}