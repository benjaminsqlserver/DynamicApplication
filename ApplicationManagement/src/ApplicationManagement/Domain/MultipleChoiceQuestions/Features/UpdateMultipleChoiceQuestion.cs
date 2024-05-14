namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Features;

using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Services;
using ApplicationManagement.Services;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Models;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateMultipleChoiceQuestion
{
    public sealed record Command(Guid MultipleChoiceQuestionId, MultipleChoiceQuestionForUpdateDto UpdatedMultipleChoiceQuestionData) : IRequest;

    public sealed class Handler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var multipleChoiceQuestionToUpdate = await multipleChoiceQuestionRepository.GetById(request.MultipleChoiceQuestionId, cancellationToken: cancellationToken);
            var multipleChoiceQuestionToAdd = request.UpdatedMultipleChoiceQuestionData.ToMultipleChoiceQuestionForUpdate();
            multipleChoiceQuestionToUpdate.Update(multipleChoiceQuestionToAdd);

            multipleChoiceQuestionRepository.Update(multipleChoiceQuestionToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}