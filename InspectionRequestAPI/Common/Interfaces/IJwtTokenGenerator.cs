using InspectionRequestAPI.Entities;

namespace InspectionRequestAPI.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);

    RefreshToken GenerateRefreshToken();    
}