namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Services;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddProgramApplicantPersonalInformation
{
    public sealed record Command(ProgramApplicantPersonalInformationForCreationDto ProgramApplicantPersonalInformationToAdd) : IRequest<ProgramApplicantPersonalInformationDto>;

    public sealed class Handler(IProgramApplicantPersonalInformationRepository programApplicantPersonalInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, ProgramApplicantPersonalInformationDto>
    {
        public async Task<ProgramApplicantPersonalInformationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var programApplicantPersonalInformationToAdd = request.ProgramApplicantPersonalInformationToAdd.ToProgramApplicantPersonalInformationForCreation();
            var programApplicantPersonalInformation = ProgramApplicantPersonalInformation.Create(programApplicantPersonalInformationToAdd);

            await programApplicantPersonalInformationRepository.Add(programApplicantPersonalInformation, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return programApplicantPersonalInformation.ToProgramApplicantPersonalInformationDto();
        }
    }
}