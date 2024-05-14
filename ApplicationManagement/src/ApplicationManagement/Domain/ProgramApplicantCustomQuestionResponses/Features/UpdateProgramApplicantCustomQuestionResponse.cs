namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateProgramApplicantCustomQuestionResponse
{
    public sealed record Command(Guid ProgramApplicantCustomQuestionResponseId, ProgramApplicantCustomQuestionResponseForUpdateDto UpdatedProgramApplicantCustomQuestionResponseData) : IRequest;

    public sealed class Handler(IProgramApplicantCustomQuestionResponseRepository programApplicantCustomQuestionResponseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var programApplicantCustomQuestionResponseToUpdate = await programApplicantCustomQuestionResponseRepository.GetById(request.ProgramApplicantCustomQuestionResponseId, cancellationToken: cancellationToken);
            var programApplicantCustomQuestionResponseToAdd = request.UpdatedProgramApplicantCustomQuestionResponseData.ToProgramApplicantCustomQuestionResponseForUpdate();
            programApplicantCustomQuestionResponseToUpdate.Update(programApplicantCustomQuestionResponseToAdd);

            programApplicantCustomQuestionResponseRepository.Update(programApplicantCustomQuestionResponseToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}