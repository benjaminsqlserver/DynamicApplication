namespace ApplicationManagement.IntegrationTests.FeatureTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class MultipleChoiceQuestionQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_multiplechoicequestion_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var multipleChoiceQuestionOne = new FakeMultipleChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(multipleChoiceQuestionOne);

        // Act
        var query = new GetMultipleChoiceQuestion.Query(multipleChoiceQuestionOne.Id);
        var multipleChoiceQuestion = await testingServiceScope.SendAsync(query);

        // Assert
        multipleChoiceQuestion.Choice.Should().Be(multipleChoiceQuestionOne.Choice);
    }

    [Fact]
    public async Task get_multiplechoicequestion_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetMultipleChoiceQuestion.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}