namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteProgramApplicantCustomQuestionResponseCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_programapplicantcustomquestionresponse_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantCustomQuestionResponse);

        // Act
        var command = new DeleteProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponse.Id);
        await testingServiceScope.SendAsync(command);
        var programApplicantCustomQuestionResponseResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.ProgramApplicantCustomQuestionResponses
                .CountAsync(p => p.Id == programApplicantCustomQuestionResponse.Id));

        // Assert
        programApplicantCustomQuestionResponseResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_programapplicantcustomquestionresponse_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteProgramApplicantCustomQuestionResponse.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_programapplicantcustomquestionresponse_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantCustomQuestionResponse);

        // Act
        var command = new DeleteProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponse.Id);
        await testingServiceScope.SendAsync(command);
        var deletedProgramApplicantCustomQuestionResponse = await testingServiceScope.ExecuteDbContextAsync(db => db.ProgramApplicantCustomQuestionResponses
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == programApplicantCustomQuestionResponse.Id));

        // Assert
        deletedProgramApplicantCustomQuestionResponse?.IsDeleted.Should().BeTrue();
    }
}