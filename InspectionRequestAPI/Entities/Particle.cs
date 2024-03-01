namespace InspectionRequestAPI.Entities;

public class Particle
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    //nanumeter,  one billionth of a meter
    public uint SizeInNm { get; set; }
    public List<ChemicalInspection> ChemicalInspections { get; set; } = new();
}