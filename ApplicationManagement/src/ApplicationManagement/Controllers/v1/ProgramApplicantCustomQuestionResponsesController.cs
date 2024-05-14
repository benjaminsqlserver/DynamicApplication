namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;
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
[Route("api/v{v:apiVersion}/programapplicantcustomquestionresponses")]
[ApiVersion("1.0")]
public sealed class ProgramApplicantCustomQuestionResponsesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new ProgramApplicantCustomQuestionResponse record.
    /// </summary>
    [HttpPost(Name = "AddProgramApplicantCustomQuestionResponse")]
    public async Task<ActionResult<ProgramApplicantCustomQuestionResponseDto>> AddProgramApplicantCustomQuestionResponse([FromBody]ProgramApplicantCustomQuestionResponseForCreationDto programApplicantCustomQuestionResponseForCreation)
    {
        var command = new AddProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponseForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetProgramApplicantCustomQuestionResponse",
            new { programApplicantCustomQuestionResponseId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single ProgramApplicantCustomQuestionResponse by ID.
    /// </summary>
    [HttpGet("{programApplicantCustomQuestionResponseId:guid}", Name = "GetProgramApplicantCustomQuestionResponse")]
    public async Task<ActionResult<ProgramApplicantCustomQuestionResponseDto>> GetProgramApplicantCustomQuestionResponse(Guid programApplicantCustomQuestionResponseId)
    {
        var query = new GetProgramApplicantCustomQuestionResponse.Query(programApplicantCustomQuestionResponseId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all ProgramApplicantCustomQuestionResponses.
    /// </summary>
    [HttpGet(Name = "GetProgramApplicantCustomQuestionResponses")]
    public async Task<IActionResult> GetProgramApplicantCustomQuestionResponses([FromQuery] ProgramApplicantCustomQuestionResponseParametersDto programApplicantCustomQuestionResponseParametersDto)
    {
        var query = new GetProgramApplicantCustomQuestionResponseList.Query(programApplicantCustomQuestionResponseParametersDto);
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
    /// Updates an entire existing ProgramApplicantCustomQuestionResponse.
    /// </summary>
    [HttpPut("{programApplicantCustomQuestionResponseId:guid}", Name = "UpdateProgramApplicantCustomQuestionResponse")]
    public async Task<IActionResult> UpdateProgramApplicantCustomQuestionResponse(Guid programApplicantCustomQuestionResponseId, ProgramApplicantCustomQuestionResponseForUpdateDto programApplicantCustomQuestionResponse)
    {
        var command = new UpdateProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponseId, programApplicantCustomQuestionResponse);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing ProgramApplicantCustomQuestionResponse record.
    /// </summary>
    [HttpDelete("{programApplicantCustomQuestionResponseId:guid}", Name = "DeleteProgramApplicantCustomQuestionResponse")]
    public async Task<ActionResult> DeleteProgramApplicantCustomQuestionResponse(Guid programApplicantCustomQuestionResponseId)
    {
        var command = new DeleteProgramApplicantCustomQuestionResponse.Command(programApplicantCustomQuestionResponseId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
