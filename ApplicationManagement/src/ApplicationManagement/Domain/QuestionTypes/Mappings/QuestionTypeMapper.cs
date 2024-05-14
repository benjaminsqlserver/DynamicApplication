namespace ApplicationManagement.Domain.QuestionTypes.Mappings;

using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.Domain.QuestionTypes.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class QuestionTypeMapper
{
    public static partial QuestionTypeForCreation ToQuestionTypeForCreation(this QuestionTypeForCreationDto questionTypeForCreationDto);
    public static partial QuestionTypeForUpdate ToQuestionTypeForUpdate(this QuestionTypeForUpdateDto questionTypeForUpdateDto);
    public static partial QuestionTypeDto ToQuestionTypeDto(this QuestionType questionType);
    public static partial IQueryable<QuestionTypeDto> ToQuestionTypeDtoQueryable(this IQueryable<QuestionType> questionType);
}