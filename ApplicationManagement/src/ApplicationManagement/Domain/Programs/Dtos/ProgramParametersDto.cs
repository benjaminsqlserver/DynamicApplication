namespace ApplicationManagement.Domain.Programs.Dtos;

using ApplicationManagement.Resources;

public sealed class ProgramParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
