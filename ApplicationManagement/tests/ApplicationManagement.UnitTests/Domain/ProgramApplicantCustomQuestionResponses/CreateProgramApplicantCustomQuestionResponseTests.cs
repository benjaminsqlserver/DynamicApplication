namespace ApplicationManagement.UnitTests.Domain.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateProgramApplicantCustomQuestionResponseTests
{
    private readonly Faker _faker;

    public CreateProgramApplicantCustomQuestionResponseTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_programApplicantCustomQuestionResponse()
    {
        // Arrange
        var programApplicantCustomQuestionResponseToCreate = new FakeProgramApplicantCustomQuestionResponseForCreation().Generate();
        
        // Act
        var programApplicantCustomQuestionResponse = ProgramApplicantCustomQuestionResponse.Create(programApplicantCustomQuestionResponseToCreate);

        // Assert
        programApplicantCustomQuestionResponse.Response.Should().Be(programApplicantCustomQuestionResponseToCreate.Response);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var programApplicantCustomQuestionResponseToCreate = new FakeProgramApplicantCustomQuestionResponseForCreation().Generate();
        
        // Act
        var programApplicantCustomQuestionResponse = ProgramApplicantCustomQuestionResponse.Create(programApplicantCustomQuestionResponseToCreate);

        // Assert
        programApplicantCustomQuestionResponse.DomainEvents.Count.Should().Be(1);
        programApplicantCustomQuestionResponse.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramApplicantCustomQuestionResponseCreated));
    }
}