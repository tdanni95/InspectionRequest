namespace InspectionRequestAPI.Entities.Helpers;

public class AuditableEntity
{
    public DateTime Created { get; set; } = DateTime.UtcNow;

    public Guid CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public Guid? LastModifiedBy { get; set; }
    public bool Visible { get; set; } = true;
}