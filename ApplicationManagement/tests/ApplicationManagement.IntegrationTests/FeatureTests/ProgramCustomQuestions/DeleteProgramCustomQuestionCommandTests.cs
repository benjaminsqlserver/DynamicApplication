namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.Domain.ProgramCustomQuestions.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteProgramCustomQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_programcustomquestion_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(programCustomQuestion);

        // Act
        var command = new DeleteProgramCustomQuestion.Command(programCustomQuestion.Id);
        await testingServiceScope.SendAsync(command);
        var programCustomQuestionResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.ProgramCustomQuestions
                .CountAsync(p => p.Id == programCustomQuestion.Id));

        // Assert
        programCustomQuestionResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_programcustomquestion_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteProgramCustomQuestion.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_programcustomquestion_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(programCustomQuestion);

        // Act
        var command = new DeleteProgramCustomQuestion.Command(programCustomQuestion.Id);
        await testingServiceScope.SendAsync(command);
        var deletedProgramCustomQuestion = await testingServiceScope.ExecuteDbContextAsync(db => db.ProgramCustomQuestions
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == programCustomQuestion.Id));

        // Assert
        deletedProgramCustomQuestion?.IsDeleted.Should().BeTrue();
    }
}