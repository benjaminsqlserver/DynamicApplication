namespace ApplicationManagement.Domain.ProgramCustomQuestions.Mappings;

using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ProgramCustomQuestionMapper
{
    public static partial ProgramCustomQuestionForCreation ToProgramCustomQuestionForCreation(this ProgramCustomQuestionForCreationDto programCustomQuestionForCreationDto);
    public static partial ProgramCustomQuestionForUpdate ToProgramCustomQuestionForUpdate(this ProgramCustomQuestionForUpdateDto programCustomQuestionForUpdateDto);
    public static partial ProgramCustomQuestionDto ToProgramCustomQuestionDto(this ProgramCustomQuestion programCustomQuestion);
    public static partial IQueryable<ProgramCustomQuestionDto> ToProgramCustomQuestionDtoQueryable(this IQueryable<ProgramCustomQuestion> programCustomQuestion);
}