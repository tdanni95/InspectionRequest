using InspectionRequestAPI.Common.Interfaces;

namespace InspectionRequestAPI.Infrastructure.Services;

public class PasswordHandler : IPasswordHandler
{
    public string HashPassword(string password)
    {
        string newPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return newPassword;
    }

    public bool VerifyPassword(string enteredPassword, string actualPassword)
    {
        bool isValidPassword = BCrypt.Net.BCrypt.Verify(enteredPassword, actualPassword);
        return isValidPassword;
    }
}