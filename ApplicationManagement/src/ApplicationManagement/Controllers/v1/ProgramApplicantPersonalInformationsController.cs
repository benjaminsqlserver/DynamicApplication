namespace ApplicationManagement.Controllers.v1;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;
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
[Route("api/v{v:apiVersion}/programapplicantpersonalinformations")]
[ApiVersion("1.0")]
public sealed class ProgramApplicantPersonalInformationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new ProgramApplicantPersonalInformation record.
    /// </summary>
    [HttpPost(Name = "AddProgramApplicantPersonalInformation")]
    public async Task<ActionResult<ProgramApplicantPersonalInformationDto>> AddProgramApplicantPersonalInformation([FromBody]ProgramApplicantPersonalInformationForCreationDto programApplicantPersonalInformationForCreation)
    {
        var command = new AddProgramApplicantPersonalInformation.Command(programApplicantPersonalInformationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetProgramApplicantPersonalInformation",
            new { programApplicantPersonalInformationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single ProgramApplicantPersonalInformation by ID.
    /// </summary>
    [HttpGet("{programApplicantPersonalInformationId:guid}", Name = "GetProgramApplicantPersonalInformation")]
    public async Task<ActionResult<ProgramApplicantPersonalInformationDto>> GetProgramApplicantPersonalInformation(Guid programApplicantPersonalInformationId)
    {
        var query = new GetProgramApplicantPersonalInformation.Query(programApplicantPersonalInformationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all ProgramApplicantPersonalInformations.
    /// </summary>
    [HttpGet(Name = "GetProgramApplicantPersonalInformations")]
    public async Task<IActionResult> GetProgramApplicantPersonalInformations([FromQuery] ProgramApplicantPersonalInformationParametersDto programApplicantPersonalInformationParametersDto)
    {
        var query = new GetProgramApplicantPersonalInformationList.Query(programApplicantPersonalInformationParametersDto);
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
    /// Updates an entire existing ProgramApplicantPersonalInformation.
    /// </summary>
    [HttpPut("{programApplicantPersonalInformationId:guid}", Name = "UpdateProgramApplicantPersonalInformation")]
    public async Task<IActionResult> UpdateProgramApplicantPersonalInformation(Guid programApplicantPersonalInformationId, ProgramApplicantPersonalInformationForUpdateDto programApplicantPersonalInformation)
    {
        var command = new UpdateProgramApplicantPersonalInformation.Command(programApplicantPersonalInformationId, programApplicantPersonalInformation);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing ProgramApplicantPersonalInformation record.
    /// </summary>
    [HttpDelete("{programApplicantPersonalInformationId:guid}", Name = "DeleteProgramApplicantPersonalInformation")]
    public async Task<ActionResult> DeleteProgramApplicantPersonalInformation(Guid programApplicantPersonalInformationId)
    {
        var command = new DeleteProgramApplicantPersonalInformation.Command(programApplicantPersonalInformationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
