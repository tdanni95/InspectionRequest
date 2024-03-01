using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Contracts.auth;
using MediatR;

namespace InspectionRequestAPI.Feateures.Users;

public record LoginQuery(string UserName, string Password) : IRequest<ErrorOr<AuthenticationResult>>;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(u => u.UserName).NotEmpty();
        RuleFor(u => u.Password).NotEmpty();
    }
}

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUnitOfWork _uow;
    private readonly IPasswordHandler _passwordHandler;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUnitOfWork uow, IPasswordHandler passwordHandler, IJwtTokenGenerator jwtTokenGenerator)
    {
        _uow = uow;
        _passwordHandler = passwordHandler;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _uow.UserRepository.GetByUsername(request.UserName);

        if (user is null) return Errors.User.InvalidCredentials;

        var isPasswordValid = _passwordHandler.VerifyPassword(request.Password, user.Password);

        if (!isPasswordValid) return Errors.User.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        user.RefreshToken = refreshToken;

        var response = new AuthenticationResult(token, refreshToken.Token);

        if(!await _uow.Complete()) return Errors.User.InvalidCredentials;

        return response!;
    }
}