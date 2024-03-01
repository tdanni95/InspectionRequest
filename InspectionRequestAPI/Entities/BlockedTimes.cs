namespace InspectionRequestAPI.Entities;

public class BlockedTimes
{
    public Guid Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public bool AllDay { get; set; } = false;
    public string Color { get; set; } = null!;
}