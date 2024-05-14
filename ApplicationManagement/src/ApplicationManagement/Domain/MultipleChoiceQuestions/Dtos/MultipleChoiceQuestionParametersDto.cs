namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;

using ApplicationManagement.Resources;

public sealed class MultipleChoiceQuestionParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
