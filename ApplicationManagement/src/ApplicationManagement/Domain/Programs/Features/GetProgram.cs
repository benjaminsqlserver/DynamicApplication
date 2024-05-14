namespace ApplicationManagement.Domain.Programs.Features;

using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.Domain.Programs.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetProgram
{
    public sealed record Query(Guid ProgramId) : IRequest<ProgramDto>;

    public sealed class Handler(IProgramRepository programRepository)
        : IRequestHandler<Query, ProgramDto>
    {
        public async Task<ProgramDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await programRepository.GetById(request.ProgramId, cancellationToken: cancellationToken);
            return result.ToProgramDto();
        }
    }
}