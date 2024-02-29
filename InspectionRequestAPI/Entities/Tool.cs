namespace InspectionRequestAPI.Entities;

public class Tool
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public List<Inspection> Inspections { get; set; } = new();
    public List<User> EngineersWhoCanUse { get; set; } = new();
}