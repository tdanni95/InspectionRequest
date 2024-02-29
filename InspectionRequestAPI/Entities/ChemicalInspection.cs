namespace InspectionRequestAPI.Entities;

public class ChemicalInspection
{
    public Guid Id { get; set; }
    public bool MustDiscardAfterInspection { get; set; }
    public string DangerComment { get; set; } = null!;
    public List<Particle> Particles { get; set; } = new();
    public InspectionRequest ParentInspection { get; set; } = null!;
}