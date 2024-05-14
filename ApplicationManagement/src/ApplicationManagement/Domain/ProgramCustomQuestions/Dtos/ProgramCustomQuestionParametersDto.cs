namespace ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;

using ApplicationManagement.Resources;

public sealed class ProgramCustomQuestionParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
