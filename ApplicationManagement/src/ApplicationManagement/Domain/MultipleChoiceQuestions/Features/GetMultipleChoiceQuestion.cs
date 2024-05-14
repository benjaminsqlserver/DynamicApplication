namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Features;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetMultipleChoiceQuestion
{
    public sealed record Query(Guid MultipleChoiceQuestionId) : IRequest<MultipleChoiceQuestionDto>;

    public sealed class Handler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        : IRequestHandler<Query, MultipleChoiceQuestionDto>
    {
        public async Task<MultipleChoiceQuestionDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await multipleChoiceQuestionRepository.GetById(request.MultipleChoiceQuestionId, cancellationToken: cancellationToken);
            return result.ToMultipleChoiceQuestionDto();
        }
    }
}