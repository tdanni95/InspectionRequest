namespace InspectionRequestAPI.Entities;

public class MechanicalInspection
{
    public Guid Id {get; set;}
    public uint Length { get; set; }
    public uint Width { get; set; }
    public uint Depth { get; set; }
    public string StructuralIntegrity { get; set; } = null!;
    public InspectionRequest ParentInspection { get; set; } = null!;
}