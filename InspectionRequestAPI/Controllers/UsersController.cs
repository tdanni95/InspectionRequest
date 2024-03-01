using InspectionRequestAPI.Contracts;
using InspectionRequestAPI.Contracts.auth;
using InspectionRequestAPI.Feateures.Users;
using InspectionRequestAPI.Feateures.Users.Register;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);
        var result = await _sender.Send(command);

        return result.Match(
            created => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var result = await _sender.Send(query);

        return result.Match(
            authresult => Ok(authresult),
            errors => Problem(errors)
        );
    }

    [HttpPost("refreshtoken")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken(TokenRefreshRequest request)
    {
        var query = _mapper.Map<TokenRefreshQuery>(request);

        var result = await _sender.Send(query);

        return result.Match(
            authresult => Ok(authresult),
            errors => Problem(errors)
        );
    }
}