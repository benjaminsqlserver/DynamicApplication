namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateProgramApplicantPersonalInformation
{
    public sealed record Command(Guid ProgramApplicantPersonalInformationId, ProgramApplicantPersonalInformationForUpdateDto UpdatedProgramApplicantPersonalInformationData) : IRequest;

    public sealed class Handler(IProgramApplicantPersonalInformationRepository programApplicantPersonalInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var programApplicantPersonalInformationToUpdate = await programApplicantPersonalInformationRepository.GetById(request.ProgramApplicantPersonalInformationId, cancellationToken: cancellationToken);
            var programApplicantPersonalInformationToAdd = request.UpdatedProgramApplicantPersonalInformationData.ToProgramApplicantPersonalInformationForUpdate();
            programApplicantPersonalInformationToUpdate.Update(programApplicantPersonalInformationToAdd);

            programApplicantPersonalInformationRepository.Update(programApplicantPersonalInformationToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}