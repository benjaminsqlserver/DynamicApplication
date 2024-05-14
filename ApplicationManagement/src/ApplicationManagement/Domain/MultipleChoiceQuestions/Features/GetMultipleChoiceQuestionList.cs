namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Features;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetMultipleChoiceQuestionList
{
    public sealed record Query(MultipleChoiceQuestionParametersDto QueryParameters) : IRequest<PagedList<MultipleChoiceQuestionDto>>;

    public sealed class Handler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        : IRequestHandler<Query, PagedList<MultipleChoiceQuestionDto>>
    {
        public async Task<PagedList<MultipleChoiceQuestionDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = multipleChoiceQuestionRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToMultipleChoiceQuestionDtoQueryable();

            return await PagedList<MultipleChoiceQuestionDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}