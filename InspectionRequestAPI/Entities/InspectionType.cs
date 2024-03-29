namespace InspectionRequestAPI.Entities;

public class InspectionType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Tool> ToolsUsedForType { get; set; } = new();
}