namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Mappings;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class MultipleChoiceQuestionMapper
{
    public static partial MultipleChoiceQuestionForCreation ToMultipleChoiceQuestionForCreation(this MultipleChoiceQuestionForCreationDto multipleChoiceQuestionForCreationDto);
    public static partial MultipleChoiceQuestionForUpdate ToMultipleChoiceQuestionForUpdate(this MultipleChoiceQuestionForUpdateDto multipleChoiceQuestionForUpdateDto);
    public static partial MultipleChoiceQuestionDto ToMultipleChoiceQuestionDto(this MultipleChoiceQuestion multipleChoiceQuestion);
    public static partial IQueryable<MultipleChoiceQuestionDto> ToMultipleChoiceQuestionDtoQueryable(this IQueryable<MultipleChoiceQuestion> multipleChoiceQuestion);
}