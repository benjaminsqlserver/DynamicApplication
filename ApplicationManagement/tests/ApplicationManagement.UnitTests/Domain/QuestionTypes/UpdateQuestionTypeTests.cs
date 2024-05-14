namespace ApplicationManagement.UnitTests.Domain.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateQuestionTypeTests
{
    private readonly Faker _faker;

    public UpdateQuestionTypeTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_questionType()
    {
        // Arrange
        var questionType = new FakeQuestionTypeBuilder().Build();
        var updatedQuestionType = new FakeQuestionTypeForUpdate().Generate();
        
        // Act
        questionType.Update(updatedQuestionType);

        // Assert
        questionType.QuestionTypeName.Should().Be(updatedQuestionType.QuestionTypeName);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var questionType = new FakeQuestionTypeBuilder().Build();
        var updatedQuestionType = new FakeQuestionTypeForUpdate().Generate();
        questionType.DomainEvents.Clear();
        
        // Act
        questionType.Update(updatedQuestionType);

        // Assert
        questionType.DomainEvents.Count.Should().Be(1);
        questionType.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(QuestionTypeUpdated));
    }
}