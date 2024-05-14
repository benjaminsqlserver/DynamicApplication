namespace ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;

using AutoBogus;
using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.Dtos;

public sealed class FakeQuestionTypeForCreationDto : AutoFaker<QuestionTypeForCreationDto>
{
    public FakeQuestionTypeForCreationDto()
    {
    }
}