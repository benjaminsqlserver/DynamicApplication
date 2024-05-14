namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;

using ApplicationManagement.Resources;

public sealed class ProgramApplicantPersonalInformationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
