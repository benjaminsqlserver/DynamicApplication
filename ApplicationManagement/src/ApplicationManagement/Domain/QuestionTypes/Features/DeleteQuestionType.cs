namespace ApplicationManagement.Domain.QuestionTypes.Features;

using ApplicationManagement.Domain.QuestionTypes.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteQuestionType
{
    public sealed record Command(Guid QuestionTypeId) : IRequest;

    public sealed class Handler(IQuestionTypeRepository questionTypeRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await questionTypeRepository.GetById(request.QuestionTypeId, cancellationToken: cancellationToken);
            questionTypeRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}