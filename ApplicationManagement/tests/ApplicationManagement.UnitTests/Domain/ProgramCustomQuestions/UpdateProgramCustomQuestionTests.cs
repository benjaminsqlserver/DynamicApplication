namespace ApplicationManagement.UnitTests.Domain.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateProgramCustomQuestionTests
{
    private readonly Faker _faker;

    public UpdateProgramCustomQuestionTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_programCustomQuestion()
    {
        // Arrange
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        var updatedProgramCustomQuestion = new FakeProgramCustomQuestionForUpdate().Generate();
        
        // Act
        programCustomQuestion.Update(updatedProgramCustomQuestion);

        // Assert
        programCustomQuestion.QuestionText.Should().Be(updatedProgramCustomQuestion.QuestionText);
        programCustomQuestion.EnableOther.Should().Be(updatedProgramCustomQuestion.EnableOther);
        programCustomQuestion.Other.Should().Be(updatedProgramCustomQuestion.Other);
        programCustomQuestion.MaxChoiceAllowed.Should().Be(updatedProgramCustomQuestion.MaxChoiceAllowed);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        var updatedProgramCustomQuestion = new FakeProgramCustomQuestionForUpdate().Generate();
        programCustomQuestion.DomainEvents.Clear();
        
        // Act
        programCustomQuestion.Update(updatedProgramCustomQuestion);

        // Assert
        programCustomQuestion.DomainEvents.Count.Should().Be(1);
        programCustomQuestion.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramCustomQuestionUpdated));
    }
}