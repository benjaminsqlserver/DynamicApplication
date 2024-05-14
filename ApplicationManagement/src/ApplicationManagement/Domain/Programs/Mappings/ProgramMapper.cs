namespace ApplicationManagement.Domain.Programs.Mappings;

using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.Domain.Programs.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ProgramMapper
{
    public static partial ProgramForCreation ToProgramForCreation(this ProgramForCreationDto programForCreationDto);
    public static partial ProgramForUpdate ToProgramForUpdate(this ProgramForUpdateDto programForUpdateDto);
    public static partial ProgramDto ToProgramDto(this Program program);
    public static partial IQueryable<ProgramDto> ToProgramDtoQueryable(this IQueryable<Program> program);
}