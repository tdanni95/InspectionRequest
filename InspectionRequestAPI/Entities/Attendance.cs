namespace InspectionRequestAPI.Entities;

public class Attendance
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Comment { get; set; } = string.Empty;
}