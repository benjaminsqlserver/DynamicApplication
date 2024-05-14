namespace ApplicationManagement.Domain.QuestionTypes.Features;

using ApplicationManagement.Domain.QuestionTypes.Services;
using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.Domain.QuestionTypes.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddQuestionType
{
    public sealed record Command(QuestionTypeForCreationDto QuestionTypeToAdd) : IRequest<QuestionTypeDto>;

    public sealed class Handler(IQuestionTypeRepository questionTypeRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, QuestionTypeDto>
    {
        public async Task<QuestionTypeDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var questionTypeToAdd = request.QuestionTypeToAdd.ToQuestionTypeForCreation();
            var questionType = QuestionType.Create(questionTypeToAdd);

            await questionTypeRepository.Add(questionType, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return questionType.ToQuestionTypeDto();
        }
    }
}