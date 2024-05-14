namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Mappings;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ProgramApplicantCustomQuestionResponseMapper
{
    public static partial ProgramApplicantCustomQuestionResponseForCreation ToProgramApplicantCustomQuestionResponseForCreation(this ProgramApplicantCustomQuestionResponseForCreationDto programApplicantCustomQuestionResponseForCreationDto);
    public static partial ProgramApplicantCustomQuestionResponseForUpdate ToProgramApplicantCustomQuestionResponseForUpdate(this ProgramApplicantCustomQuestionResponseForUpdateDto programApplicantCustomQuestionResponseForUpdateDto);
    public static partial ProgramApplicantCustomQuestionResponseDto ToProgramApplicantCustomQuestionResponseDto(this ProgramApplicantCustomQuestionResponse programApplicantCustomQuestionResponse);
    public static partial IQueryable<ProgramApplicantCustomQuestionResponseDto> ToProgramApplicantCustomQuestionResponseDtoQueryable(this IQueryable<ProgramApplicantCustomQuestionResponse> programApplicantCustomQuestionResponse);
}