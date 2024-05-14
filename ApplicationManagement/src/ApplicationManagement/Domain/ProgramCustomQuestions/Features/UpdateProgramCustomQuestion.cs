namespace ApplicationManagement.Domain.ProgramCustomQuestions.Features;

using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.Domain.ProgramCustomQuestions.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateProgramCustomQuestion
{
    public sealed record Command(Guid ProgramCustomQuestionId, ProgramCustomQuestionForUpdateDto UpdatedProgramCustomQuestionData) : IRequest;

    public sealed class Handler(IProgramCustomQuestionRepository programCustomQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var programCustomQuestionToUpdate = await programCustomQuestionRepository.GetById(request.ProgramCustomQuestionId, cancellationToken: cancellationToken);
            var programCustomQuestionToAdd = request.UpdatedProgramCustomQuestionData.ToProgramCustomQuestionForUpdate();
            programCustomQuestionToUpdate.Update(programCustomQuestionToAdd);

            programCustomQuestionRepository.Update(programCustomQuestionToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}