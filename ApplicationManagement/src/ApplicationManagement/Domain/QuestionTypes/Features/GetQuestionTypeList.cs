namespace ApplicationManagement.Domain.QuestionTypes.Features;

using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.Domain.QuestionTypes.Services;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetQuestionTypeList
{
    public sealed record Query(QuestionTypeParametersDto QueryParameters) : IRequest<PagedList<QuestionTypeDto>>;

    public sealed class Handler(IQuestionTypeRepository questionTypeRepository)
        : IRequestHandler<Query, PagedList<QuestionTypeDto>>
    {
        public async Task<PagedList<QuestionTypeDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = questionTypeRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToQuestionTypeDtoQueryable();

            return await PagedList<QuestionTypeDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}