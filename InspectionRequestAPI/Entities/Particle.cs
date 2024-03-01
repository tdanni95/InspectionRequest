namespace InspectionRequestAPI.Entities;

public class Particle
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public uint Size { get; set; }
    public List<ChemicalInspection> ChemicalInspections { get; set; } = new();
}