using InspectionRequestAPI.Common.Models;

namespace InspectionRequestAPI.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}