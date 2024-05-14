namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Features;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetDropdownChoiceQuestionList
{
    public sealed record Query(DropdownChoiceQuestionParametersDto QueryParameters) : IRequest<PagedList<DropdownChoiceQuestionDto>>;

    public sealed class Handler(IDropdownChoiceQuestionRepository dropdownChoiceQuestionRepository)
        : IRequestHandler<Query, PagedList<DropdownChoiceQuestionDto>>
    {
        public async Task<PagedList<DropdownChoiceQuestionDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dropdownChoiceQuestionRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToDropdownChoiceQuestionDtoQueryable();

            return await PagedList<DropdownChoiceQuestionDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}