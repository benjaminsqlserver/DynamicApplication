namespace ApplicationManagement.IntegrationTests.FeatureTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.Domain.Programs.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteProgramCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_program_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var program = new FakeProgramBuilder().Build();
        await testingServiceScope.InsertAsync(program);

        // Act
        var command = new DeleteProgram.Command(program.Id);
        await testingServiceScope.SendAsync(command);
        var programResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Programs
                .CountAsync(p => p.Id == program.Id));

        // Assert
        programResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_program_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteProgram.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_program_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var program = new FakeProgramBuilder().Build();
        await testingServiceScope.InsertAsync(program);

        // Act
        var command = new DeleteProgram.Command(program.Id);
        await testingServiceScope.SendAsync(command);
        var deletedProgram = await testingServiceScope.ExecuteDbContextAsync(db => db.Programs
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == program.Id));

        // Assert
        deletedProgram?.IsDeleted.Should().BeTrue();
    }
}