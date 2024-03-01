namespace InspectionRequestAPI.Entities;

public class Inspection
{
    public Guid Id { get; set; }
    public Examination Examination { get; set; } = null!;
    public User? PerformedBy { get; set; }
    public DateTime? FinishedAd { get; set; }
    public uint Order { get; set; } = 1;
    public List<InspectionRequest> InspectionRequests { get; set; } = new();
}
