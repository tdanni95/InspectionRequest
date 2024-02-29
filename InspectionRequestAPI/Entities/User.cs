namespace InspectionRequestAPI.Entities;

public class User
{
    public Guid Id { get; set; }
    public bool IsEngineer { get; set; } = false;
    public bool IsAdmin { get; set; } = false;
    public string ForName { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Tool> ToolsICanUse { get; set; } = new();
    public List<Attendance> Attendances { get; set; } = new();
}