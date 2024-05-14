namespace ApplicationManagement.Domain.Programs.Features;

using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Dtos;
using ApplicationManagement.Domain.Programs.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.Programs.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateProgram
{
    public sealed record Command(Guid ProgramId, ProgramForUpdateDto UpdatedProgramData) : IRequest;

    public sealed class Handler(IProgramRepository programRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var programToUpdate = await programRepository.GetById(request.ProgramId, cancellationToken: cancellationToken);
            var programToAdd = request.UpdatedProgramData.ToProgramForUpdate();
            programToUpdate.Update(programToAdd);

            programRepository.Update(programToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}