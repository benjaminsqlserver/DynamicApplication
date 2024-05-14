namespace ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;

using AutoBogus;
using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.Dtos;

public sealed class FakeQuestionTypeForUpdateDto : AutoFaker<QuestionTypeForUpdateDto>
{
    public FakeQuestionTypeForUpdateDto()
    {
    }
}