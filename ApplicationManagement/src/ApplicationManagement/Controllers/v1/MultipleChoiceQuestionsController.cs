namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.MultipleChoiceQuestions.Features;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;
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
[Route("api/v{v:apiVersion}/multiplechoicequestions")]
[ApiVersion("1.0")]
public sealed class MultipleChoiceQuestionsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new MultipleChoiceQuestion record.
    /// </summary>
    [HttpPost(Name = "AddMultipleChoiceQuestion")]
    public async Task<ActionResult<MultipleChoiceQuestionDto>> AddMultipleChoiceQuestion([FromBody]MultipleChoiceQuestionForCreationDto multipleChoiceQuestionForCreation)
    {
        var command = new AddMultipleChoiceQuestion.Command(multipleChoiceQuestionForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetMultipleChoiceQuestion",
            new { multipleChoiceQuestionId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single MultipleChoiceQuestion by ID.
    /// </summary>
    [HttpGet("{multipleChoiceQuestionId:guid}", Name = "GetMultipleChoiceQuestion")]
    public async Task<ActionResult<MultipleChoiceQuestionDto>> GetMultipleChoiceQuestion(Guid multipleChoiceQuestionId)
    {
        var query = new GetMultipleChoiceQuestion.Query(multipleChoiceQuestionId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all MultipleChoiceQuestions.
    /// </summary>
    [HttpGet(Name = "GetMultipleChoiceQuestions")]
    public async Task<IActionResult> GetMultipleChoiceQuestions([FromQuery] MultipleChoiceQuestionParametersDto multipleChoiceQuestionParametersDto)
    {
        var query = new GetMultipleChoiceQuestionList.Query(multipleChoiceQuestionParametersDto);
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
    /// Updates an entire existing MultipleChoiceQuestion.
    /// </summary>
    [HttpPut("{multipleChoiceQuestionId:guid}", Name = "UpdateMultipleChoiceQuestion")]
    public async Task<IActionResult> UpdateMultipleChoiceQuestion(Guid multipleChoiceQuestionId, MultipleChoiceQuestionForUpdateDto multipleChoiceQuestion)
    {
        var command = new UpdateMultipleChoiceQuestion.Command(multipleChoiceQuestionId, multipleChoiceQuestion);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing MultipleChoiceQuestion record.
    /// </summary>
    [HttpDelete("{multipleChoiceQuestionId:guid}", Name = "DeleteMultipleChoiceQuestion")]
    public async Task<ActionResult> DeleteMultipleChoiceQuestion(Guid multipleChoiceQuestionId)
    {
        var command = new DeleteMultipleChoiceQuestion.Command(multipleChoiceQuestionId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
