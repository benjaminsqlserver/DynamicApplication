namespace ApplicationManagement.Domain.ProgramCustomQuestions.Features;

using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.Domain.ProgramCustomQuestions.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetProgramCustomQuestion
{
    public sealed record Query(Guid ProgramCustomQuestionId) : IRequest<ProgramCustomQuestionDto>;

    public sealed class Handler(IProgramCustomQuestionRepository programCustomQuestionRepository)
        : IRequestHandler<Query, ProgramCustomQuestionDto>
    {
        public async Task<ProgramCustomQuestionDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await programCustomQuestionRepository.GetById(request.ProgramCustomQuestionId, cancellationToken: cancellationToken);
            return result.ToProgramCustomQuestionDto();
        }
    }
}