using InspectionRequestAPI.Contracts;
using InspectionRequestAPI.Feateures.Users.Register;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InspectionRequestAPI.Controllers;

public class UsersController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UsersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);
        var result = await _sender.Send(command);

        return result.Match(
            created => NoContent(),
            errors => Problem(errors)
        );
    }
}