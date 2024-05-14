namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;

public class AddProgramApplicantCustomQuestionResponseCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_programapplicantcustomquestionresponse_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantCustomQuestionResponseOne = new FakeProgramApplicantCustomQuestionResponseForCreationDto().Generate();

        // Act
        var command = new AddProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponseOne);
        var programApplicantCustomQuestionResponseReturned = await testingServiceScope.SendAsync(command);
        var programApplicantCustomQuestionResponseCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.ProgramApplicantCustomQuestionResponses
            .FirstOrDefaultAsync(p => p.Id == programApplicantCustomQuestionResponseReturned.Id));

        // Assert
        programApplicantCustomQuestionResponseReturned.Response.Should().Be(programApplicantCustomQuestionResponseOne.Response);

        programApplicantCustomQuestionResponseCreated.Response.Should().Be(programApplicantCustomQuestionResponseOne.Response);
    }
}