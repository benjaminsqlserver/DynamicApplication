namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Mappings;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class DropdownChoiceQuestionMapper
{
    public static partial DropdownChoiceQuestionForCreation ToDropdownChoiceQuestionForCreation(this DropdownChoiceQuestionForCreationDto dropdownChoiceQuestionForCreationDto);
    public static partial DropdownChoiceQuestionForUpdate ToDropdownChoiceQuestionForUpdate(this DropdownChoiceQuestionForUpdateDto dropdownChoiceQuestionForUpdateDto);
    public static partial DropdownChoiceQuestionDto ToDropdownChoiceQuestionDto(this DropdownChoiceQuestion dropdownChoiceQuestion);
    public static partial IQueryable<DropdownChoiceQuestionDto> ToDropdownChoiceQuestionDtoQueryable(this IQueryable<DropdownChoiceQuestion> dropdownChoiceQuestion);
}