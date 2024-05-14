namespace ApplicationManagement.IntegrationTests.FeatureTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateDropdownChoiceQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_dropdownchoicequestion_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(dropdownChoiceQuestion);
        var updatedDropdownChoiceQuestionDto = new FakeDropdownChoiceQuestionForUpdateDto().Generate();

        // Act
        var command = new UpdateDropdownChoiceQuestion.Command(dropdownChoiceQuestion.Id, updatedDropdownChoiceQuestionDto);
        await testingServiceScope.SendAsync(command);
        var updatedDropdownChoiceQuestion = await testingServiceScope
            .ExecuteDbContextAsync(db => db.DropdownChoiceQuestions
                .FirstOrDefaultAsync(d => d.Id == dropdownChoiceQuestion.Id));

        // Assert
        updatedDropdownChoiceQuestion.Choice.Should().Be(updatedDropdownChoiceQuestionDto.Choice);
    }
}