using System.Security.Claims;

namespace InspectionRequestAPI.Common.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserName(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value;
    }

    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var u = user.FindFirst(ClaimTypes.NameIdentifier);
        if (u is not null)
        {
            return Guid.Parse(u.Value);
        }
        return null;
    }
}