namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Features;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Services;
using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddMultipleChoiceQuestion
{
    public sealed record Command(MultipleChoiceQuestionForCreationDto MultipleChoiceQuestionToAdd) : IRequest<MultipleChoiceQuestionDto>;

    public sealed class Handler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, MultipleChoiceQuestionDto>
    {
        public async Task<MultipleChoiceQuestionDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var multipleChoiceQuestionToAdd = request.MultipleChoiceQuestionToAdd.ToMultipleChoiceQuestionForCreation();
            var multipleChoiceQuestion = MultipleChoiceQuestion.Create(multipleChoiceQuestionToAdd);

            await multipleChoiceQuestionRepository.Add(multipleChoiceQuestion, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return multipleChoiceQuestion.ToMultipleChoiceQuestionDto();
        }
    }
}