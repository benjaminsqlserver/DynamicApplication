namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Features;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Services;
using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Models;
using ApplicationManagement.Services;
using ApplicationManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddDropdownChoiceQuestion
{
    public sealed record Command(DropdownChoiceQuestionForCreationDto DropdownChoiceQuestionToAdd) : IRequest<DropdownChoiceQuestionDto>;

    public sealed class Handler(IDropdownChoiceQuestionRepository dropdownChoiceQuestionRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, DropdownChoiceQuestionDto>
    {
        public async Task<DropdownChoiceQuestionDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var dropdownChoiceQuestionToAdd = request.DropdownChoiceQuestionToAdd.ToDropdownChoiceQuestionForCreation();
            var dropdownChoiceQuestion = DropdownChoiceQuestion.Create(dropdownChoiceQuestionToAdd);

            await dropdownChoiceQuestionRepository.Add(dropdownChoiceQuestion, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return dropdownChoiceQuestion.ToDropdownChoiceQuestionDto();
        }
    }
}