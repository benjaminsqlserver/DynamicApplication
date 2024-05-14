namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;

using ApplicationManagement.Resources;

public sealed class ProgramApplicantCustomQuestionResponseParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
