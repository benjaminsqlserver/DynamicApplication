namespace ApplicationManagement.Domain.ProgramCustomQuestions.Features;

using ApplicationManagement.Domain.ProgramCustomQuestions.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteProgramCustomQuestion
{
    public sealed record Command(Guid ProgramCustomQuestionId) : IRequest;

    public sealed class Handler(IProgramCustomQuestionRepository programCustomQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await programCustomQuestionRepository.GetById(request.ProgramCustomQuestionId, cancellationToken: cancellationToken);
            programCustomQuestionRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}