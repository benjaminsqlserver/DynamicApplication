namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Mappings;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ProgramApplicantPersonalInformationMapper
{
    public static partial ProgramApplicantPersonalInformationForCreation ToProgramApplicantPersonalInformationForCreation(this ProgramApplicantPersonalInformationForCreationDto programApplicantPersonalInformationForCreationDto);
    public static partial ProgramApplicantPersonalInformationForUpdate ToProgramApplicantPersonalInformationForUpdate(this ProgramApplicantPersonalInformationForUpdateDto programApplicantPersonalInformationForUpdateDto);
    public static partial ProgramApplicantPersonalInformationDto ToProgramApplicantPersonalInformationDto(this ProgramApplicantPersonalInformation programApplicantPersonalInformation);
    public static partial IQueryable<ProgramApplicantPersonalInformationDto> ToProgramApplicantPersonalInformationDtoQueryable(this IQueryable<ProgramApplicantPersonalInformation> programApplicantPersonalInformation);
}