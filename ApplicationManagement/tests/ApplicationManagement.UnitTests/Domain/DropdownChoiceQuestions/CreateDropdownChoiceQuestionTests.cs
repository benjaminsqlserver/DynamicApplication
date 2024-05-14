namespace ApplicationManagement.UnitTests.Domain.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateDropdownChoiceQuestionTests
{
    private readonly Faker _faker;

    public CreateDropdownChoiceQuestionTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_dropdownChoiceQuestion()
    {
        // Arrange
        var dropdownChoiceQuestionToCreate = new FakeDropdownChoiceQuestionForCreation().Generate();
        
        // Act
        var dropdownChoiceQuestion = DropdownChoiceQuestion.Create(dropdownChoiceQuestionToCreate);

        // Assert
        dropdownChoiceQuestion.Choice.Should().Be(dropdownChoiceQuestionToCreate.Choice);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var dropdownChoiceQuestionToCreate = new FakeDropdownChoiceQuestionForCreation().Generate();
        
        // Act
        var dropdownChoiceQuestion = DropdownChoiceQuestion.Create(dropdownChoiceQuestionToCreate);

        // Assert
        dropdownChoiceQuestion.DomainEvents.Count.Should().Be(1);
        dropdownChoiceQuestion.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DropdownChoiceQuestionCreated));
    }
}