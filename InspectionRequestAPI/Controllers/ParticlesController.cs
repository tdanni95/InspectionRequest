using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using InspectionRequestAPI.Feateures.Particles;
using Microsoft.AspNetCore.Mvc;
using InspectionRequestAPI.Contracts.particles;
using MapsterMapper;

namespace InspectionRequestAPI.Controllers;

public class ParticlesController(ISender _sender, IMapper _mapper) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllParticlesQuery();
        var result = await _sender.Send(query);

        return result.Match(
            particles => Ok( _mapper.Map<List<ParticleResponse>>(particles)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateParticle(CreateParticleRequest request)
    {
        var command = new CreateParticleCommand(request.Name, request.SizeInNm);
        var result = await _sender.Send(command);

        return result.Match(
            id => Ok(new { id = id }),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateParticle(UpdateParticleRequest request)
    {
        var command = new UpdateParticleCommand(request.Id, request.Name, request.SizeInNm);
        var result = await _sender.Send(command);

        return result.Match(
            updated => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteParticle(Guid id)
    {
        var command = new DeleteParticleCommand(id);
        var result = await _sender.Send(command);

        return result.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}