namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteProgramApplicantPersonalInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_programapplicantpersonalinformation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantPersonalInformation);

        // Act
        var command = new DeleteProgramApplicantPersonalInformation.Command(programApplicantPersonalInformation.Id);
        await testingServiceScope.SendAsync(command);
        var programApplicantPersonalInformationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.ProgramApplicantPersonalInformations
                .CountAsync(p => p.Id == programApplicantPersonalInformation.Id));

        // Assert
        programApplicantPersonalInformationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_programapplicantpersonalinformation_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteProgramApplicantPersonalInformation.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_programapplicantpersonalinformation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantPersonalInformation = new FakeProgramApplicantPersonalInformationBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantPersonalInformation);

        // Act
        var command = new DeleteProgramApplicantPersonalInformation.Command(programApplicantPersonalInformation.Id);
        await testingServiceScope.SendAsync(command);
        var deletedProgramApplicantPersonalInformation = await testingServiceScope.ExecuteDbContextAsync(db => db.ProgramApplicantPersonalInformations
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == programApplicantPersonalInformation.Id));

        // Assert
        deletedProgramApplicantPersonalInformation?.IsDeleted.Should().BeTrue();
    }
}