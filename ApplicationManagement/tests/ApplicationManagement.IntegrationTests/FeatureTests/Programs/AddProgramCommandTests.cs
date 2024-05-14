namespace ApplicationManagement.IntegrationTests.FeatureTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.Programs.Features;

public class AddProgramCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_program_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programOne = new FakeProgramForCreationDto().Generate();

        // Act
        var command = new AddProgram.Command(programOne);
        var programReturned = await testingServiceScope.SendAsync(command);
        var programCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Programs
            .FirstOrDefaultAsync(p => p.Id == programReturned.Id));

        // Assert
        programReturned.ProgramDescription.Should().Be(programOne.ProgramDescription);

        programCreated.ProgramDescription.Should().Be(programOne.ProgramDescription);
    }
}