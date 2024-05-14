namespace ApplicationManagement.IntegrationTests.FeatureTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.Domain.QuestionTypes.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteQuestionTypeCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_questiontype_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var questionType = new FakeQuestionTypeBuilder().Build();
        await testingServiceScope.InsertAsync(questionType);

        // Act
        var command = new DeleteQuestionType.Command(questionType.Id);
        await testingServiceScope.SendAsync(command);
        var questionTypeResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.QuestionTypes
                .CountAsync(q => q.Id == questionType.Id));

        // Assert
        questionTypeResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_questiontype_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteQuestionType.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_questiontype_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var questionType = new FakeQuestionTypeBuilder().Build();
        await testingServiceScope.InsertAsync(questionType);

        // Act
        var command = new DeleteQuestionType.Command(questionType.Id);
        await testingServiceScope.SendAsync(command);
        var deletedQuestionType = await testingServiceScope.ExecuteDbContextAsync(db => db.QuestionTypes
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == questionType.Id));

        // Assert
        deletedQuestionType?.IsDeleted.Should().BeTrue();
    }
}