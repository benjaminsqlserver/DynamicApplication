namespace ApplicationManagement.Domain.QuestionTypes.Dtos;

using ApplicationManagement.Resources;

public sealed class QuestionTypeParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
