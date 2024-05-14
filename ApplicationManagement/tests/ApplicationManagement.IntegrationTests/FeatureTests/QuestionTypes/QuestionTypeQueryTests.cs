namespace ApplicationManagement.IntegrationTests.FeatureTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.Domain.QuestionTypes.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class QuestionTypeQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_questiontype_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var questionTypeOne = new FakeQuestionTypeBuilder().Build();
        await testingServiceScope.InsertAsync(questionTypeOne);

        // Act
        var query = new GetQuestionType.Query(questionTypeOne.Id);
        var questionType = await testingServiceScope.SendAsync(query);

        // Assert
        questionType.QuestionTypeName.Should().Be(questionTypeOne.QuestionTypeName);
    }

    [Fact]
    public async Task get_questiontype_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetQuestionType.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}