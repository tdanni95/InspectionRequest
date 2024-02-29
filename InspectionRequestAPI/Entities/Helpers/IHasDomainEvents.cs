using InspectionRequestAPI.Common.Models;

namespace InspectionRequestAPI.Entities.Helpers;

public interface IHasDomainEvents
{
    public List<DomainEvent> DomainEvents { get; }
}