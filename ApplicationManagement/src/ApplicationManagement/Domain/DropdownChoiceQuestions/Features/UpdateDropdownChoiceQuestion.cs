namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Features;

using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateDropdownChoiceQuestion
{
    public sealed record Command(Guid DropdownChoiceQuestionId, DropdownChoiceQuestionForUpdateDto UpdatedDropdownChoiceQuestionData) : IRequest;

    public sealed class Handler(IDropdownChoiceQuestionRepository dropdownChoiceQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var dropdownChoiceQuestionToUpdate = await dropdownChoiceQuestionRepository.GetById(request.DropdownChoiceQuestionId, cancellationToken: cancellationToken);
            var dropdownChoiceQuestionToAdd = request.UpdatedDropdownChoiceQuestionData.ToDropdownChoiceQuestionForUpdate();
            dropdownChoiceQuestionToUpdate.Update(dropdownChoiceQuestionToAdd);

            dropdownChoiceQuestionRepository.Update(dropdownChoiceQuestionToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}