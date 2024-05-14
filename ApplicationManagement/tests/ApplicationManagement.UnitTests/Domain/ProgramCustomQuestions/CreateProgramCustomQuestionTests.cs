namespace ApplicationManagement.UnitTests.Domain.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateProgramCustomQuestionTests
{
    private readonly Faker _faker;

    public CreateProgramCustomQuestionTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_programCustomQuestion()
    {
        // Arrange
        var programCustomQuestionToCreate = new FakeProgramCustomQuestionForCreation().Generate();
        
        // Act
        var programCustomQuestion = ProgramCustomQuestion.Create(programCustomQuestionToCreate);

        // Assert
        programCustomQuestion.QuestionText.Should().Be(programCustomQuestionToCreate.QuestionText);
        programCustomQuestion.EnableOther.Should().Be(programCustomQuestionToCreate.EnableOther);
        programCustomQuestion.Other.Should().Be(programCustomQuestionToCreate.Other);
        programCustomQuestion.MaxChoiceAllowed.Should().Be(programCustomQuestionToCreate.MaxChoiceAllowed);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var programCustomQuestionToCreate = new FakeProgramCustomQuestionForCreation().Generate();
        
        // Act
        var programCustomQuestion = ProgramCustomQuestion.Create(programCustomQuestionToCreate);

        // Assert
        programCustomQuestion.DomainEvents.Count.Should().Be(1);
        programCustomQuestion.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramCustomQuestionCreated));
    }
}