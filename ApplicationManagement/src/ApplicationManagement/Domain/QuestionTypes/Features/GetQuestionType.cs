namespace ApplicationManagement.Domain.QuestionTypes.Features;

using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.Domain.QuestionTypes.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetQuestionType
{
    public sealed record Query(Guid QuestionTypeId) : IRequest<QuestionTypeDto>;

    public sealed class Handler(IQuestionTypeRepository questionTypeRepository)
        : IRequestHandler<Query, QuestionTypeDto>
    {
        public async Task<QuestionTypeDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await questionTypeRepository.GetById(request.QuestionTypeId, cancellationToken: cancellationToken);
            return result.ToQuestionTypeDto();
        }
    }
}