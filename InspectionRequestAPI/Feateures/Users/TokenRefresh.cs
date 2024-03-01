using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Contracts.auth;
using MediatR;

namespace InspectionRequestAPI.Feateures.Users;

public record TokenRefreshQuery(string Token) : IRequest<ErrorOr<AuthenticationResult>>;

public class TokenRefreshQueryValidator : AbstractValidator<TokenRefreshQuery>
{
    public TokenRefreshQueryValidator()
    {
        RuleFor(tr => tr.Token).NotEmpty();
    }
}

public class TokenRefreshQueryHandler : IRequestHandler<TokenRefreshQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUnitOfWork _uow;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public TokenRefreshQueryHandler(IUnitOfWork uow, IJwtTokenGenerator jwtTokenGenerator, IDateTimeProvider dateTimeProvider)
    {
        _uow = uow;
        _jwtTokenGenerator = jwtTokenGenerator;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(TokenRefreshQuery request, CancellationToken cancellationToken)
    {
        var user = await _uow.UserRepository.GetByRefreshToken(request.Token);
        var now = _dateTimeProvider.Now;

        if (user is null) return Errors.User.InvalidCredentials;

        if (user.RefreshToken is null || user.RefreshToken.Expires < now) return Errors.User.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);
        var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;

        if (!await _uow.Complete()) return Errors.User.InvalidCredentials;

        return new AuthenticationResult(token, newRefreshToken.Token);
    }
}