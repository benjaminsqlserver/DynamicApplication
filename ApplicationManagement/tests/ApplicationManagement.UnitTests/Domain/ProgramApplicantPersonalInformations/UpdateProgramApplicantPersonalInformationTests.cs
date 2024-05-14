namespace ApplicationManagement.UnitTests.Domain.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateProgramApplicantPersonalInformationTests
{
    private readonly Faker _faker;

    public UpdateProgramApplicantPersonalInformationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_programApplicantPersonalInformation()
    {
        // Arrange
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        var updatedProgramApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationForUpdate().Generate();
        
        // Act
        programApplicantPersonalInformation.Update(updatedProgramApplicantPersonalInformation);

        // Assert
        programApplicantPersonalInformation.FirstName.Should().Be(updatedProgramApplicantPersonalInformation.FirstName);
        programApplicantPersonalInformation.LastName.Should().Be(updatedProgramApplicantPersonalInformation.LastName);
        programApplicantPersonalInformation.Email.Should().Be(updatedProgramApplicantPersonalInformation.Email);
        programApplicantPersonalInformation.Phone.Should().Be(updatedProgramApplicantPersonalInformation.Phone);
        programApplicantPersonalInformation.Nationality.Should().Be(updatedProgramApplicantPersonalInformation.Nationality);
        programApplicantPersonalInformation.CurrentResidence.Should().Be(updatedProgramApplicantPersonalInformation.CurrentResidence);
        programApplicantPersonalInformation.IdNumber.Should().Be(updatedProgramApplicantPersonalInformation.IdNumber);
        programApplicantPersonalInformation.Gender.Should().Be(updatedProgramApplicantPersonalInformation.Gender);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        var updatedProgramApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationForUpdate().Generate();
        programApplicantPersonalInformation.DomainEvents.Clear();
        
        // Act
        programApplicantPersonalInformation.Update(updatedProgramApplicantPersonalInformation);

        // Assert
        programApplicantPersonalInformation.DomainEvents.Count.Should().Be(1);
        programApplicantPersonalInformation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramApplicantPersonalInformationUpdated));
    }
}