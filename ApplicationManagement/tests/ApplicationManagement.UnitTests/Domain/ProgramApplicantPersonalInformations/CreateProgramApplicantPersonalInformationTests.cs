namespace ApplicationManagement.UnitTests.Domain.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateProgramApplicantPersonalInformationTests
{
    private readonly Faker _faker;

    public CreateProgramApplicantPersonalInformationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_programApplicantPersonalInformation()
    {
        // Arrange
        var programApplicantPersonalInformationToCreate = new FakeProgramApplicantPersonalInformationForCreation().Generate();
        
        // Act
        var programApplicantPersonalInformation = ProgramApplicantPersonalInformation.Create(programApplicantPersonalInformationToCreate);

        // Assert
        programApplicantPersonalInformation.FirstName.Should().Be(programApplicantPersonalInformationToCreate.FirstName);
        programApplicantPersonalInformation.LastName.Should().Be(programApplicantPersonalInformationToCreate.LastName);
        programApplicantPersonalInformation.Email.Should().Be(programApplicantPersonalInformationToCreate.Email);
        programApplicantPersonalInformation.Phone.Should().Be(programApplicantPersonalInformationToCreate.Phone);
        programApplicantPersonalInformation.Nationality.Should().Be(programApplicantPersonalInformationToCreate.Nationality);
        programApplicantPersonalInformation.CurrentResidence.Should().Be(programApplicantPersonalInformationToCreate.CurrentResidence);
        programApplicantPersonalInformation.IdNumber.Should().Be(programApplicantPersonalInformationToCreate.IdNumber);
        programApplicantPersonalInformation.Gender.Should().Be(programApplicantPersonalInformationToCreate.Gender);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var programApplicantPersonalInformationToCreate = new FakeProgramApplicantPersonalInformationForCreation().Generate();
        
        // Act
        var programApplicantPersonalInformation = ProgramApplicantPersonalInformation.Create(programApplicantPersonalInformationToCreate);

        // Assert
        programApplicantPersonalInformation.DomainEvents.Count.Should().Be(1);
        programApplicantPersonalInformation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramApplicantPersonalInformationCreated));
    }
}