namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.Domain.ProgramCustomQuestions.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateProgramCustomQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_programcustomquestion_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programCustomQuestion = new FakeProgramCustomQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(programCustomQuestion);
        var updatedProgramCustomQuestionDto = new FakeProgramCustomQuestionForUpdateDto().Generate();

        // Act
        var command = new UpdateProgramCustomQuestion.Command(programCustomQuestion.Id, updatedProgramCustomQuestionDto);
        await testingServiceScope.SendAsync(command);
        var updatedProgramCustomQuestion = await testingServiceScope
            .ExecuteDbContextAsync(db => db.ProgramCustomQuestions
                .FirstOrDefaultAsync(p => p.Id == programCustomQuestion.Id));

        // Assert
        updatedProgramCustomQuestion.QuestionText.Should().Be(updatedProgramCustomQuestionDto.QuestionText);
        updatedProgramCustomQuestion.EnableOther.Should().Be(updatedProgramCustomQuestionDto.EnableOther);
        updatedProgramCustomQuestion.Other.Should().Be(updatedProgramCustomQuestionDto.Other);
        updatedProgramCustomQuestion.MaxChoiceAllowed.Should().Be(updatedProgramCustomQuestionDto.MaxChoiceAllowed);
    }
}