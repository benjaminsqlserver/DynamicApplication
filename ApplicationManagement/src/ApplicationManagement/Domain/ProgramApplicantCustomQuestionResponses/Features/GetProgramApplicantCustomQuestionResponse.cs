namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetProgramApplicantCustomQuestionResponse
{
    public sealed record Query(Guid ProgramApplicantCustomQuestionResponseId) : IRequest<ProgramApplicantCustomQuestionResponseDto>;

    public sealed class Handler(IProgramApplicantCustomQuestionResponseRepository programApplicantCustomQuestionResponseRepository)
        : IRequestHandler<Query, ProgramApplicantCustomQuestionResponseDto>
    {
        public async Task<ProgramApplicantCustomQuestionResponseDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await programApplicantCustomQuestionResponseRepository.GetById(request.ProgramApplicantCustomQuestionResponseId, cancellationToken: cancellationToken);
            return result.ToProgramApplicantCustomQuestionResponseDto();
        }
    }
}