namespace ApplicationManagement.Domain.Programs.Features;

using ApplicationManagement.Domain.Programs.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteProgram
{
    public sealed record Command(Guid ProgramId) : IRequest;

    public sealed class Handler(IProgramRepository programRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await programRepository.GetById(request.ProgramId, cancellationToken: cancellationToken);
            programRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}