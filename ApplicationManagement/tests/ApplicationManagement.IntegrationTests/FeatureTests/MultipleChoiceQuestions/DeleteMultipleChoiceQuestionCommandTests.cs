namespace ApplicationManagement.IntegrationTests.FeatureTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteMultipleChoiceQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_multiplechoicequestion_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(multipleChoiceQuestion);

        // Act
        var command = new DeleteMultipleChoiceQuestion.Command(multipleChoiceQuestion.Id);
        await testingServiceScope.SendAsync(command);
        var multipleChoiceQuestionResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.MultipleChoiceQuestions
                .CountAsync(m => m.Id == multipleChoiceQuestion.Id));

        // Assert
        multipleChoiceQuestionResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_multiplechoicequestion_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteMultipleChoiceQuestion.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_multiplechoicequestion_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(multipleChoiceQuestion);

        // Act
        var command = new DeleteMultipleChoiceQuestion.Command(multipleChoiceQuestion.Id);
        await testingServiceScope.SendAsync(command);
        var deletedMultipleChoiceQuestion = await testingServiceScope.ExecuteDbContextAsync(db => db.MultipleChoiceQuestions
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == multipleChoiceQuestion.Id));

        // Assert
        deletedMultipleChoiceQuestion?.IsDeleted.Should().BeTrue();
    }
}