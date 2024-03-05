using InspectionRequestAPI.Common.Extensions;
using InspectionRequestAPI.Common.Interfaces;

namespace InspectionRequestAPI.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Guid? UserId => _httpContextAccessor.HttpContext!.User.GetUserId();

    public string? UserName => _httpContextAccessor.HttpContext!.User.GetUserName()!;
}