namespace ApplicationManagement.UnitTests.Domain.Programs;

using ApplicationManagement.SharedTestHelpers.Fakes.Program;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = ApplicationManagement.Exceptions.ValidationException;

public class CreateProgramTests
{
    private readonly Faker _faker;

    public CreateProgramTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_program()
    {
        // Arrange
        var programToCreate = new FakeProgramForCreation().Generate();
        
        // Act
        var program = Program.Create(programToCreate);

        // Assert
        program.ProgramDescription.Should().Be(programToCreate.ProgramDescription);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var programToCreate = new FakeProgramForCreation().Generate();
        
        // Act
        var program = Program.Create(programToCreate);

        // Assert
        program.DomainEvents.Count.Should().Be(1);
        program.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ProgramCreated));
    }
}