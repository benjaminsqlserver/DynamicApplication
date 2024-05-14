namespace ApplicationManagement.IntegrationTests.FeatureTests.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.Domain.Programs.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProgramQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_program_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programOne = new FakeProgramBuilder().Build();
        await testingServiceScope.InsertAsync(programOne);

        // Act
        var query = new GetProgram.Query(programOne.Id);
        var program = await testingServiceScope.SendAsync(query);

        // Assert
        program.ProgramDescription.Should().Be(programOne.ProgramDescription);
    }

    [Fact]
    public async Task get_program_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetProgram.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}