namespace InspectionRequestAPI.Contracts.auth;

public record AuthenticationResult(string Token, string RefreshToken);