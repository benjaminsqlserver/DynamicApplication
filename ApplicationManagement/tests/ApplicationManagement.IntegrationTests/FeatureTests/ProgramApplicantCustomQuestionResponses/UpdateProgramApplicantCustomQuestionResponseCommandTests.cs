namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateProgramApplicantCustomQuestionResponseCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_programapplicantcustomquestionresponse_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantCustomQuestionResponse = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantCustomQuestionResponse);
        var updatedProgramApplicantCustomQuestionResponseDto = new FakeProgramApplicantCustomQuestionResponseForUpdateDto().Generate();

        // Act
        var command = new UpdateProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponse.Id, updatedProgramApplicantCustomQuestionResponseDto);
        await testingServiceScope.SendAsync(command);
        var updatedProgramApplicantCustomQuestionResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.ProgramApplicantCustomQuestionResponses
                .FirstOrDefaultAsync(p => p.Id == programApplicantCustomQuestionResponse.Id));

        // Assert
        updatedProgramApplicantCustomQuestionResponse.Response.Should().Be(updatedProgramApplicantCustomQuestionResponseDto.Response);
    }
}