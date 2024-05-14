namespace ApplicationManagement.UnitTests.Domain.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateProgramApplicantCustomQuestionResponseTests
{
    private readonly Faker _faker;

    public UpdateProgramApplicantCustomQuestionResponseTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_programApplicantCustomQuestionResponse()
    {
        // Arrange
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        var updatedProgramApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseForUpdate().Generate();
        
        // Act
        programApplicantCustomQuestionResponse.Update(updatedProgramApplicantCustomQuestionResponse);

        // Assert
        programApplicantCustomQuestionResponse.Response.Should().Be(updatedProgramApplicantCustomQuestionResponse.Response);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        var updatedProgramApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseForUpdate().Generate();
        programApplicantCustomQuestionResponse.DomainEvents.Clear();
        
        // Act
        programApplicantCustomQuestionResponse.Update(updatedProgramApplicantCustomQuestionResponse);

        // Assert
        programApplicantCustomQuestionResponse.DomainEvents.Count.Should().Be(1);
        programApplicantCustomQuestionResponse.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramApplicantCustomQuestionResponseUpdated));
    }
}