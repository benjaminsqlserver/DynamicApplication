namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.QuestionTypes.Features;
using ApplicationManagement.Domain.QuestionTypes.Dtos;
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
[Route("api/v{v:apiVersion}/questiontypes")]
[ApiVersion("1.0")]
public sealed class QuestionTypesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new QuestionType record.
    /// </summary>
    [HttpPost(Name = "AddQuestionType")]
    public async Task<ActionResult<QuestionTypeDto>> AddQuestionType([FromBody]QuestionTypeForCreationDto questionTypeForCreation)
    {
        var command = new AddQuestionType.Command(questionTypeForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetQuestionType",
            new { questionTypeId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single QuestionType by ID.
    /// </summary>
    [HttpGet("{questionTypeId:guid}", Name = "GetQuestionType")]
    public async Task<ActionResult<QuestionTypeDto>> GetQuestionType(Guid questionTypeId)
    {
        var query = new GetQuestionType.Query(questionTypeId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all QuestionTypes.
    /// </summary>
    [HttpGet(Name = "GetQuestionTypes")]
    public async Task<IActionResult> GetQuestionTypes([FromQuery] QuestionTypeParametersDto questionTypeParametersDto)
    {
        var query = new GetQuestionTypeList.Query(questionTypeParametersDto);
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
    /// Updates an entire existing QuestionType.
    /// </summary>
    [HttpPut("{questionTypeId:guid}", Name = "UpdateQuestionType")]
    public async Task<IActionResult> UpdateQuestionType(Guid questionTypeId, QuestionTypeForUpdateDto questionType)
    {
        var command = new UpdateQuestionType.Command(questionTypeId, questionType);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing QuestionType record.
    /// </summary>
    [HttpDelete("{questionTypeId:guid}", Name = "DeleteQuestionType")]
    public async Task<ActionResult> DeleteQuestionType(Guid questionTypeId)
    {
        var command = new DeleteQuestionType.Command(questionTypeId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
