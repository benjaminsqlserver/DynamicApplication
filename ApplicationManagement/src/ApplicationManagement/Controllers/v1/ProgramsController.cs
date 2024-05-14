namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.Programs.Features;
using ApplicationManagement.Domain.Programs.Dtos;
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
[Route("api/v{v:apiVersion}/programs")]
[ApiVersion("1.0")]
public sealed class ProgramsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Program record.
    /// </summary>
    [HttpPost(Name = "AddProgram")]
    public async Task<ActionResult<ProgramDto>> AddProgram([FromBody]ProgramForCreationDto programForCreation)
    {
        var command = new AddProgram.Command(programForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetProgram",
            new { programId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Program by ID.
    /// </summary>
    [HttpGet("{programId:guid}", Name = "GetProgram")]
    public async Task<ActionResult<ProgramDto>> GetProgram(Guid programId)
    {
        var query = new GetProgram.Query(programId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Programs.
    /// </summary>
    [HttpGet(Name = "GetPrograms")]
    public async Task<IActionResult> GetPrograms([FromQuery] ProgramParametersDto programParametersDto)
    {
        var query = new GetProgramList.Query(programParametersDto);
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
    /// Updates an entire existing Program.
    /// </summary>
    [HttpPut("{programId:guid}", Name = "UpdateProgram")]
    public async Task<IActionResult> UpdateProgram(Guid programId, ProgramForUpdateDto program)
    {
        var command = new UpdateProgram.Command(programId, program);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Program record.
    /// </summary>
    [HttpDelete("{programId:guid}", Name = "DeleteProgram")]
    public async Task<ActionResult> DeleteProgram(Guid programId)
    {
        var command = new DeleteProgram.Command(programId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
