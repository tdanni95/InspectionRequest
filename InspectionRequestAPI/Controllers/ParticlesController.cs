using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using InspectionRequestAPI.Feateures.Particles;
using Microsoft.AspNetCore.Mvc;
using InspectionRequestAPI.Contracts.particles;

namespace InspectionRequestAPI.Controllers;

public class ParticlesController(ISender _sender) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllParticlesQuery();
        var result = await _sender.Send(query);

        return result.Match(
            particles => Ok(particles),
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
}