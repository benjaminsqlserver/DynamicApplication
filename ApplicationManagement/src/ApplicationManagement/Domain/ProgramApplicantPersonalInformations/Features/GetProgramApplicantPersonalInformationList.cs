namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetProgramApplicantPersonalInformationList
{
    public sealed record Query(ProgramApplicantPersonalInformationParametersDto QueryParameters) : IRequest<PagedList<ProgramApplicantPersonalInformationDto>>;

    public sealed class Handler(IProgramApplicantPersonalInformationRepository programApplicantPersonalInformationRepository)
        : IRequestHandler<Query, PagedList<ProgramApplicantPersonalInformationDto>>
    {
        public async Task<PagedList<ProgramApplicantPersonalInformationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = programApplicantPersonalInformationRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToProgramApplicantPersonalInformationDtoQueryable();

            return await PagedList<ProgramApplicantPersonalInformationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}