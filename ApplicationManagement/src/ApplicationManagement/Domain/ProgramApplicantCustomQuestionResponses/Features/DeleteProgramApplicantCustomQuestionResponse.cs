namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteProgramApplicantCustomQuestionResponse
{
    public sealed record Command(Guid ProgramApplicantCustomQuestionResponseId) : IRequest;

    public sealed class Handler(IProgramApplicantCustomQuestionResponseRepository programApplicantCustomQuestionResponseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await programApplicantCustomQuestionResponseRepository.GetById(request.ProgramApplicantCustomQuestionResponseId, cancellationToken: cancellationToken);
            programApplicantCustomQuestionResponseRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}