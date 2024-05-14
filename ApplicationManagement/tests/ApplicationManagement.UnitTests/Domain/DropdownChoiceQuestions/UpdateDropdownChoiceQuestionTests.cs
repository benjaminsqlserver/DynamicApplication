namespace ApplicationManagement.UnitTests.Domain.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateDropdownChoiceQuestionTests
{
    private readonly Faker _faker;

    public UpdateDropdownChoiceQuestionTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_dropdownChoiceQuestion()
    {
        // Arrange
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        var updatedDropdownChoiceQuestion = new FakeDropdownChoiceQuestionForUpdate().Generate();
        
        // Act
        dropdownChoiceQuestion.Update(updatedDropdownChoiceQuestion);

        // Assert
        dropdownChoiceQuestion.Choice.Should().Be(updatedDropdownChoiceQuestion.Choice);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        var updatedDropdownChoiceQuestion = new FakeDropdownChoiceQuestionForUpdate().Generate();
        dropdownChoiceQuestion.DomainEvents.Clear();
        
        // Act
        dropdownChoiceQuestion.Update(updatedDropdownChoiceQuestion);

        // Assert
        dropdownChoiceQuestion.DomainEvents.Count.Should().Be(1);
        dropdownChoiceQuestion.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DropdownChoiceQuestionUpdated));
    }
}