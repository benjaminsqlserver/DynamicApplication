namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Features;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetDropdownChoiceQuestion
{
    public sealed record Query(Guid DropdownChoiceQuestionId) : IRequest<DropdownChoiceQuestionDto>;

    public sealed class Handler(IDropdownChoiceQuestionRepository dropdownChoiceQuestionRepository)
        : IRequestHandler<Query, DropdownChoiceQuestionDto>
    {
        public async Task<DropdownChoiceQuestionDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dropdownChoiceQuestionRepository.GetById(request.DropdownChoiceQuestionId, cancellationToken: cancellationToken);
            return result.ToDropdownChoiceQuestionDto();
        }
    }
}