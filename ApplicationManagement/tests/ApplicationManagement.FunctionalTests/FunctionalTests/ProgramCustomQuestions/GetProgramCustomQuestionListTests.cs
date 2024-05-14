namespace ApplicationManagement.FunctionalTests.FunctionalTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetProgramCustomQuestionListTests : TestBase
{
    [Fact]
    public async Task get_programcustomquestion_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.ProgramCustomQuestions.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}