namespace InspectionRequestAPI.Contracts;

public record RegisterRequest(
    string ForName,
    string SurName,
    string Login,
    string Password,
    string Email,
    string PhoneNumber
);