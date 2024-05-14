namespace ApplicationManagement.UnitTests.Domain.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateMultipleChoiceQuestionTests
{
    private readonly Faker _faker;

    public CreateMultipleChoiceQuestionTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_multipleChoiceQuestion()
    {
        // Arrange
        var multipleChoiceQuestionToCreate = new FakeMultipleChoiceQuestionForCreation().Generate();
        
        // Act
        var multipleChoiceQuestion = MultipleChoiceQuestion.Create(multipleChoiceQuestionToCreate);

        // Assert
        multipleChoiceQuestion.Choice.Should().Be(multipleChoiceQuestionToCreate.Choice);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var multipleChoiceQuestionToCreate = new FakeMultipleChoiceQuestionForCreation().Generate();
        
        // Act
        var multipleChoiceQuestion = MultipleChoiceQuestion.Create(multipleChoiceQuestionToCreate);

        // Assert
        multipleChoiceQuestion.DomainEvents.Count.Should().Be(1);
        multipleChoiceQuestion.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(MultipleChoiceQuestionCreated));
    }
}