namespace ApplicationManagement.Domain.ProgramCustomQuestions.Features;

using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.Domain.ProgramCustomQuestions.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetProgramCustomQuestionList
{
    public sealed record Query(ProgramCustomQuestionParametersDto QueryParameters) : IRequest<PagedList<ProgramCustomQuestionDto>>;

    public sealed class Handler(IProgramCustomQuestionRepository programCustomQuestionRepository)
        : IRequestHandler<Query, PagedList<ProgramCustomQuestionDto>>
    {
        public async Task<PagedList<ProgramCustomQuestionDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = programCustomQuestionRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToProgramCustomQuestionDtoQueryable();

            return await PagedList<ProgramCustomQuestionDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}