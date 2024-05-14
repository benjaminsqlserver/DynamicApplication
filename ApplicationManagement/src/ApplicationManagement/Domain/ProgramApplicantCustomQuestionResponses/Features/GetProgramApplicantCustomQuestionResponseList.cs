namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetProgramApplicantCustomQuestionResponseList
{
    public sealed record Query(ProgramApplicantCustomQuestionResponseParametersDto QueryParameters) : IRequest<PagedList<ProgramApplicantCustomQuestionResponseDto>>;

    public sealed class Handler(IProgramApplicantCustomQuestionResponseRepository programApplicantCustomQuestionResponseRepository)
        : IRequestHandler<Query, PagedList<ProgramApplicantCustomQuestionResponseDto>>
    {
        public async Task<PagedList<ProgramApplicantCustomQuestionResponseDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = programApplicantCustomQuestionResponseRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToProgramApplicantCustomQuestionResponseDtoQueryable();

            return await PagedList<ProgramApplicantCustomQuestionResponseDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}