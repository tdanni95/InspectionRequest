using InspectionRequestAPI.Entities.Helpers;

namespace InspectionRequestAPI.Entities;

public class InspectionRequest : AuditableEntity
{
    public Guid Id { get; set; }
    public string PartNumber { get; set; } = null!;
    public User Requestor { get; set; } = null!;
    public string RequestorRequest { get; set; } = null!;
    public bool IsWaste { get; set; } = false;
    public uint Prio { get; set; }
    public uint SubPrio { get; set; }
    public DateTime? FinishDate { get; set; }
    public List<Inspection> Inspections { get; set; } = new();
    public InspectionType InspectionType { get; set; } = null!;
}