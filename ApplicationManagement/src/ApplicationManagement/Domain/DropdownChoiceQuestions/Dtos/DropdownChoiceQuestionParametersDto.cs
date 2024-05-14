namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;

using ApplicationManagement.Resources;

public sealed class DropdownChoiceQuestionParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
