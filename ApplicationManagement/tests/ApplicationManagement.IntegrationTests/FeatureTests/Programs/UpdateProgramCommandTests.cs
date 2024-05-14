namespace ApplicationManagement.IntegrationTests.FeatureTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.Domain.Programs.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateProgramCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_program_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var program = new FakeProgramBuilder().Build();
        await testingServiceScope.InsertAsync(program);
        var updatedProgramDto = new FakeProgramForUpdateDto().Generate();

        // Act
        var command = new UpdateProgram.Command(program.Id, updatedProgramDto);
        await testingServiceScope.SendAsync(command);
        var updatedProgram = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Programs
                .FirstOrDefaultAsync(p => p.Id == program.Id));

        // Assert
        updatedProgram.ProgramDescription.Should().Be(updatedProgramDto.ProgramDescription);
    }
}