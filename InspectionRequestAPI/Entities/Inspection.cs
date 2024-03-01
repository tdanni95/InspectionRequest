namespace InspectionRequestAPI.Entities;

public class Inspection
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? FinishedAd { get; set; }
    public uint Order { get; set; } = 1;
    public Tool Tool { get; set; } = null!;
    public List<InspectionRequest> InspectionRequests { get; set; } = new();
}
