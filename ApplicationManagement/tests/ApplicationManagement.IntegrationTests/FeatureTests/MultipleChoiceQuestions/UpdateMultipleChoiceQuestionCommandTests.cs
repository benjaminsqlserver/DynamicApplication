namespace ApplicationManagement.IntegrationTests.FeatureTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateMultipleChoiceQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_multiplechoicequestion_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var multipleChoiceQuestion = new FakeMultipleChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(multipleChoiceQuestion);
        var updatedMultipleChoiceQuestionDto = new FakeMultipleChoiceQuestionForUpdateDto().Generate();

        // Act
        var command = new UpdateMultipleChoiceQuestion.Command(multipleChoiceQuestion.Id, updatedMultipleChoiceQuestionDto);
        await testingServiceScope.SendAsync(command);
        var updatedMultipleChoiceQuestion = await testingServiceScope
            .ExecuteDbContextAsync(db => db.MultipleChoiceQuestions
                .FirstOrDefaultAsync(m => m.Id == multipleChoiceQuestion.Id));

        // Assert
        updatedMultipleChoiceQuestion.Choice.Should().Be(updatedMultipleChoiceQuestionDto.Choice);
    }
}