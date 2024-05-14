namespace ApplicationManagement.UnitTests.Domain.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class UpdateProgramTests
{
    private readonly Faker _faker;

    public UpdateProgramTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_program()
    {
        // Arrange
        var program = new FakeProgramBuilder().Build();
        var updatedProgram = new FakeProgramForUpdate().Generate();
        
        // Act
        program.Update(updatedProgram);

        // Assert
        program.ProgramDescription.Should().Be(updatedProgram.ProgramDescription);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var program = new FakeProgramBuilder().Build();
        var updatedProgram = new FakeProgramForUpdate().Generate();
        program.DomainEvents.Clear();
        
        // Act
        program.Update(updatedProgram);

        // Assert
        program.DomainEvents.Count.Should().Be(1);
        program.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramUpdated));
    }
}