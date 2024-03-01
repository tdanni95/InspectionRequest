namespace InspectionRequestAPI.Common.Interfaces;

public interface IPasswordHandler
{
    string HashPassword(string password);
    bool VerifyPassword(string enteredPassword, string actualPassword);
}