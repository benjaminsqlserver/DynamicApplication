namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetProgramApplicantPersonalInformation
{
    public sealed record Query(Guid ProgramApplicantPersonalInformationId) : IRequest<ProgramApplicantPersonalInformationDto>;

    public sealed class Handler(IProgramApplicantPersonalInformationRepository programApplicantPersonalInformationRepository)
        : IRequestHandler<Query, ProgramApplicantPersonalInformationDto>
    {
        public async Task<ProgramApplicantPersonalInformationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await programApplicantPersonalInformationRepository.GetById(request.ProgramApplicantPersonalInformationId, cancellationToken: cancellationToken);
            return result.ToProgramApplicantPersonalInformationDto();
        }
    }
}