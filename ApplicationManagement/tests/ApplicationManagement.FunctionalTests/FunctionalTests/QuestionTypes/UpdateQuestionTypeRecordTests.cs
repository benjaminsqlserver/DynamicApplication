namespace ApplicationManagement.FunctionalTests.FunctionalTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateQuestionTypeRecordTests : TestBase
{
    [Fact]
    public async Task put_questiontype_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var questionType = new FakeQuestionTypeBuilder().Build();
        var updatedQuestionTypeDto = new FakeQuestionTypeForUpdateDto().Generate();
        await InsertAsync(questionType);

        // Act
        var route = ApiRoutes.QuestionTypes.Put(questionType.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedQuestionTypeDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}