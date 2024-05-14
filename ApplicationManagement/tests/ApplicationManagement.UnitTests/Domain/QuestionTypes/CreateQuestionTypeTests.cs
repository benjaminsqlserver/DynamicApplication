namespace ApplicationManagement.UnitTests.Domain.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateQuestionTypeTests
{
    private readonly Faker _faker;

    public CreateQuestionTypeTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_questionType()
    {
        // Arrange
        var questionTypeToCreate = new FakeQuestionTypeForCreation().Generate();
        
        // Act
        var questionType = QuestionType.Create(questionTypeToCreate);

        // Assert
        questionType.QuestionTypeName.Should().Be(questionTypeToCreate.QuestionTypeName);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var questionTypeToCreate = new FakeQuestionTypeForCreation().Generate();
        
        // Act
        var questionType = QuestionType.Create(questionTypeToCreate);

        // Assert
        questionType.DomainEvents.Count.Should().Be(1);
        questionType.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(QuestionTypeCreated));
    }
}