namespace InspectionRequestAPI.Common.Models;

public abstract class DomainEvent
{
    protected DomainEvent()
    {
        DateOccurred = DateTime.UtcNow;
    }
    public bool IsPublished { get; set; }
    public DateTimeOffset DateOccurred { get; protected set; }
}