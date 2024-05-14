namespace ApplicationManagement.IntegrationTests.FeatureTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.Domain.QuestionTypes.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateQuestionTypeCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_questiontype_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var questionType = new FakeQuestionTypeBuilder().Build();
        await testingServiceScope.InsertAsync(questionType);
        var updatedQuestionTypeDto = new FakeQuestionTypeForUpdateDto().Generate();

        // Act
        var command = new UpdateQuestionType.Command(questionType.Id, updatedQuestionTypeDto);
        await testingServiceScope.SendAsync(command);
        var updatedQuestionType = await testingServiceScope
            .ExecuteDbContextAsync(db => db.QuestionTypes
                .FirstOrDefaultAsync(q => q.Id == questionType.Id));

        // Assert
        updatedQuestionType.QuestionTypeName.Should().Be(updatedQuestionTypeDto.QuestionTypeName);
    }
}