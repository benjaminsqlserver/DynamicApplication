namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Features;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using MediatR;

public static class DeleteDropdownChoiceQuestion
{
    public sealed record Command(Guid DropdownChoiceQuestionId) : IRequest;

    public sealed class Handler(IDropdownChoiceQuestionRepository dropdownChoiceQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dropdownChoiceQuestionRepository.GetById(request.DropdownChoiceQuestionId, cancellationToken: cancellationToken);
            dropdownChoiceQuestionRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}