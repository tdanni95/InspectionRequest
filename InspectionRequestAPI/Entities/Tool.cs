namespace InspectionRequestAPI.Entities;

public class Tool
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public List<Examination> Inspections { get; set; } = new();
    
    public InspectionType UsedForType { get; set; } = null!;
    public List<User> EngineersWhoCanUse { get; set; } = new();
}