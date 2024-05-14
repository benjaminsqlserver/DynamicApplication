namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Features;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteMultipleChoiceQuestion
{
    public sealed record Command(Guid MultipleChoiceQuestionId) : IRequest;

    public sealed class Handler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await multipleChoiceQuestionRepository.GetById(request.MultipleChoiceQuestionId, cancellationToken: cancellationToken);
            multipleChoiceQuestionRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}