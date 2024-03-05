using InspectionRequestAPI.Contracts.tools;
using InspectionRequestAPI.Feateures.Tools;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InspectionRequestAPI.Controllers;

public class ToolsController(ISender _sender, IMapper _mapper) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllToolsQuery();
        var result = await _sender.Send(query);

        return result.Match(
            tools => Ok(_mapper.Map<List<ToolResponse>>(tools)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateTool(CreateToolRequest request)
    {
        var command = new CreateToolCommand(request.Name, request.InspectionTypeId);
        var result = await _sender.Send(command);

        return result.Match(
            id => Ok(id),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateParticle(UpdateToolRequest request)
    {
        var command = new UpdateToolCommand(request.Id, request.Name, request.InspectionTypeId);
        var result = await _sender.Send(command);

        return result.Match(
            updated => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteParticle(Guid id)
    {
        var command = new DeleteToolCommand(id);
        var result = await _sender.Send(command);

        return result.Match(
            updated => NoContent(),
            errors => Problem(errors)
        );
    }
}