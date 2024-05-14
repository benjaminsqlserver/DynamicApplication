namespace ApplicationManagement.FunctionalTests.FunctionalTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteQuestionTypeTests : TestBase
{
    [Fact]
    public async Task delete_questiontype_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var questionType = new FakeQuestionTypeBuilder().Build();
        await InsertAsync(questionType);

        // Act
        var route = ApiRoutes.QuestionTypes.Delete(questionType.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}