namespace ApplicationManagement.UnitTests.Domain.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateMultipleChoiceQuestionTests
{
    private readonly Faker _faker;

    public UpdateMultipleChoiceQuestionTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_multipleChoiceQuestion()
    {
        // Arrange
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        var updatedMultipleChoiceQuestion = new FakeMultipleChoiceQuestionForUpdate().Generate();
        
        // Act
        multipleChoiceQuestion.Update(updatedMultipleChoiceQuestion);

        // Assert
        multipleChoiceQuestion.Choice.Should().Be(updatedMultipleChoiceQuestion.Choice);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        var updatedMultipleChoiceQuestion = new FakeMultipleChoiceQuestionForUpdate().Generate();
        multipleChoiceQuestion.DomainEvents.Clear();
        
        // Act
        multipleChoiceQuestion.Update(updatedMultipleChoiceQuestion);

        // Assert
        multipleChoiceQuestion.DomainEvents.Count.Should().Be(1);
        multipleChoiceQuestion.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(MultipleChoiceQuestionUpdated));
    }
}