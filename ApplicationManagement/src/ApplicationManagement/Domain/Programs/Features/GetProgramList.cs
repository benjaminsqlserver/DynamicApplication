namespace ApplicationManagement.Domain.Programs.Features;

using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.Domain.Programs.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetProgramList
{
    public sealed record Query(ProgramParametersDto QueryParameters) : IRequest<PagedList<ProgramDto>>;

    public sealed class Handler(IProgramRepository programRepository)
        : IRequestHandler<Query, PagedList<ProgramDto>>
    {
        public async Task<PagedList<ProgramDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = programRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToProgramDtoQueryable();

            return await PagedList<ProgramDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}