namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteProgramApplicantPersonalInformation
{
    public sealed record Command(Guid ProgramApplicantPersonalInformationId) : IRequest;

    public sealed class Handler(IProgramApplicantPersonalInformationRepository programApplicantPersonalInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await programApplicantPersonalInformationRepository.GetById(request.ProgramApplicantPersonalInformationId, cancellationToken: cancellationToken);
            programApplicantPersonalInformationRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}