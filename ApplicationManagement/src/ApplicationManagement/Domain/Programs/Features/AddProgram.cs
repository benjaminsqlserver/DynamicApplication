namespace ApplicationManagement.Domain.Programs.Features;

using ApplicationManagement.Domain.Programs.Services;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.Domain.Programs.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddProgram
{
    public sealed record Command(ProgramForCreationDto ProgramToAdd) : IRequest<ProgramDto>;

    public sealed class Handler(IProgramRepository programRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, ProgramDto>
    {
        public async Task<ProgramDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var programToAdd = request.ProgramToAdd.ToProgramForCreation();
            var program = Program.Create(programToAdd);

            await programRepository.Add(program, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return program.ToProgramDto();
        }
    }
}