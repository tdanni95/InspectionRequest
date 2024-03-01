namespace InspectionRequestAPI.Entities;

public class Examination
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Tool ToolUsedToPerform { get; set; } = null!;
}