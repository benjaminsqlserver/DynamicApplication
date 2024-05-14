namespace ApplicationManagement.IntegrationTests.FeatureTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteDropdownChoiceQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_dropdownchoicequestion_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(dropdownChoiceQuestion);

        // Act
        var command = new DeleteDropdownChoiceQuestion.Command(dropdownChoiceQuestion.Id);
        await testingServiceScope.SendAsync(command);
        var dropdownChoiceQuestionResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.DropdownChoiceQuestions
                .CountAsync(d => d.Id == dropdownChoiceQuestion.Id));

        // Assert
        dropdownChoiceQuestionResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_dropdownchoicequestion_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteDropdownChoiceQuestion.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_dropdownchoicequestion_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var dropdownChoiceQuestion = new FakeDropdownChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(dropdownChoiceQuestion);

        // Act
        var command = new DeleteDropdownChoiceQuestion.Command(dropdownChoiceQuestion.Id);
        await testingServiceScope.SendAsync(command);
        var deletedDropdownChoiceQuestion = await testingServiceScope.ExecuteDbContextAsync(db => db.DropdownChoiceQuestions
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == dropdownChoiceQuestion.Id));

        // Assert
        deletedDropdownChoiceQuestion?.IsDeleted.Should().BeTrue();
    }
}