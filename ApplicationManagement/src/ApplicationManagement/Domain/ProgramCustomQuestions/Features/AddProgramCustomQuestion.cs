namespace ApplicationManagement.Domain.ProgramCustomQuestions.Features;

using ApplicationManagement.Domain.ProgramCustomQuestions.Services;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddProgramCustomQuestion
{
    public sealed record Command(ProgramCustomQuestionForCreationDto ProgramCustomQuestionToAdd) : IRequest<ProgramCustomQuestionDto>;

    public sealed class Handler(IProgramCustomQuestionRepository programCustomQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, ProgramCustomQuestionDto>
    {
        public async Task<ProgramCustomQuestionDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var programCustomQuestionToAdd = request.ProgramCustomQuestionToAdd.ToProgramCustomQuestionForCreation();
            var programCustomQuestion = ProgramCustomQuestion.Create(programCustomQuestionToAdd);

            await programCustomQuestionRepository.Add(programCustomQuestion, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return programCustomQuestion.ToProgramCustomQuestionDto();
        }
    }
}