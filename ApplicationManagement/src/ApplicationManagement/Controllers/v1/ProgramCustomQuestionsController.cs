namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.ProgramCustomQuestions.Features;
using ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;
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
[Route("api/v{v:apiVersion}/programcustomquestions")]
[ApiVersion("1.0")]
public sealed class ProgramCustomQuestionsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new ProgramCustomQuestion record.
    /// </summary>
    [HttpPost(Name = "AddProgramCustomQuestion")]
    public async Task<ActionResult<ProgramCustomQuestionDto>> AddProgramCustomQuestion([FromBody]ProgramCustomQuestionForCreationDto programCustomQuestionForCreation)
    {
        var command = new AddProgramCustomQuestion.Command(programCustomQuestionForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetProgramCustomQuestion",
            new { programCustomQuestionId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single ProgramCustomQuestion by ID.
    /// </summary>
    [HttpGet("{programCustomQuestionId:guid}", Name = "GetProgramCustomQuestion")]
    public async Task<ActionResult<ProgramCustomQuestionDto>> GetProgramCustomQuestion(Guid programCustomQuestionId)
    {
        var query = new GetProgramCustomQuestion.Query(programCustomQuestionId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all ProgramCustomQuestions.
    /// </summary>
    [HttpGet(Name = "GetProgramCustomQuestions")]
    public async Task<IActionResult> GetProgramCustomQuestions([FromQuery] ProgramCustomQuestionParametersDto programCustomQuestionParametersDto)
    {
        var query = new GetProgramCustomQuestionList.Query(programCustomQuestionParametersDto);
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
    /// Updates an entire existing ProgramCustomQuestion.
    /// </summary>
    [HttpPut("{programCustomQuestionId:guid}", Name = "UpdateProgramCustomQuestion")]
    public async Task<IActionResult> UpdateProgramCustomQuestion(Guid programCustomQuestionId, ProgramCustomQuestionForUpdateDto programCustomQuestion)
    {
        var command = new UpdateProgramCustomQuestion.Command(programCustomQuestionId, programCustomQuestion);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing ProgramCustomQuestion record.
    /// </summary>
    [HttpDelete("{programCustomQuestionId:guid}", Name = "DeleteProgramCustomQuestion")]
    public async Task<ActionResult> DeleteProgramCustomQuestion(Guid programCustomQuestionId)
    {
        var command = new DeleteProgramCustomQuestion.Command(programCustomQuestionId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
