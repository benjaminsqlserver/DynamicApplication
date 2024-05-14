namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.DropdownChoiceQuestions.Features;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;
using ApplicationManagement.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/dropdownchoicequestions")]
[ApiVersion("1.0")]
public sealed class DropdownChoiceQuestionsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new DropdownChoiceQuestion record.
    /// </summary>
    [HttpPost(Name = "AddDropdownChoiceQuestion")]
    public async Task<ActionResult<DropdownChoiceQuestionDto>> AddDropdownChoiceQuestion([FromBody]DropdownChoiceQuestionForCreationDto dropdownChoiceQuestionForCreation)
    {
        var command = new AddDropdownChoiceQuestion.Command(dropdownChoiceQuestionForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetDropdownChoiceQuestion",
            new { dropdownChoiceQuestionId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single DropdownChoiceQuestion by ID.
    /// </summary>
    [HttpGet("{dropdownChoiceQuestionId:guid}", Name = "GetDropdownChoiceQuestion")]
    public async Task<ActionResult<DropdownChoiceQuestionDto>> GetDropdownChoiceQuestion(Guid dropdownChoiceQuestionId)
    {
        var query = new GetDropdownChoiceQuestion.Query(dropdownChoiceQuestionId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all DropdownChoiceQuestions.
    /// </summary>
    [HttpGet(Name = "GetDropdownChoiceQuestions")]
    public async Task<IActionResult> GetDropdownChoiceQuestions([FromQuery] DropdownChoiceQuestionParametersDto dropdownChoiceQuestionParametersDto)
    {
        var query = new GetDropdownChoiceQuestionList.Query(dropdownChoiceQuestionParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing DropdownChoiceQuestion.
    /// </summary>
    [HttpPut("{dropdownChoiceQuestionId:guid}", Name = "UpdateDropdownChoiceQuestion")]
    public async Task<IActionResult> UpdateDropdownChoiceQuestion(Guid dropdownChoiceQuestionId, DropdownChoiceQuestionForUpdateDto dropdownChoiceQuestion)
    {
        var command = new UpdateDropdownChoiceQuestion.Command(dropdownChoiceQuestionId, dropdownChoiceQuestion);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing DropdownChoiceQuestion record.
    /// </summary>
    [HttpDelete("{dropdownChoiceQuestionId:guid}", Name = "DeleteDropdownChoiceQuestion")]
    public async Task<ActionResult> DeleteDropdownChoiceQuestion(Guid dropdownChoiceQuestionId)
    {
        var command = new DeleteDropdownChoiceQuestion.Command(dropdownChoiceQuestionId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
