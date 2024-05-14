namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Services;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddProgramApplicantCustomQuestionResponse
{
    public sealed record Command(ProgramApplicantCustomQuestionResponseForCreationDto ProgramApplicantCustomQuestionResponseToAdd) : IRequest<ProgramApplicantCustomQuestionResponseDto>;

    public sealed class Handler(IProgramApplicantCustomQuestionResponseRepository programApplicantCustomQuestionResponseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, ProgramApplicantCustomQuestionResponseDto>
    {
        public async Task<ProgramApplicantCustomQuestionResponseDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var programApplicantCustomQuestionResponseToAdd = request.ProgramApplicantCustomQuestionResponseToAdd.ToProgramApplicantCustomQuestionResponseForCreation();
            var programApplicantCustomQuestionResponse = ProgramApplicantCustomQuestionResponse.Create(programApplicantCustomQuestionResponseToAdd);

            await programApplicantCustomQuestionResponseRepository.Add(programApplicantCustomQuestionResponse, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return programApplicantCustomQuestionResponse.ToProgramApplicantCustomQuestionResponseDto();
        }
    }
}