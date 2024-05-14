namespace ApplicationManagement.Domain.QuestionTypes.Features;

using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.Dtos;
using ApplicationManagement.Domain.QuestionTypes.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.QuestionTypes.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateQuestionType
{
    public sealed record Command(Guid QuestionTypeId, QuestionTypeForUpdateDto UpdatedQuestionTypeData) : IRequest;

    public sealed class Handler(IQuestionTypeRepository questionTypeRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var questionTypeToUpdate = await questionTypeRepository.GetById(request.QuestionTypeId, cancellationToken: cancellationToken);
            var questionTypeToAdd = request.UpdatedQuestionTypeData.ToQuestionTypeForUpdate();
            questionTypeToUpdate.Update(questionTypeToAdd);

            questionTypeRepository.Update(questionTypeToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}