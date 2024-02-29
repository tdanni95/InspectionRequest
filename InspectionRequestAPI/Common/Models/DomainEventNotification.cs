using MediatR;

namespace InspectionRequestAPI.Common.Models;

public class DomainEventNotification<TDomainEvent>: INotification where TDomainEvent : DomainEvent
{
    public TDomainEvent DomainEvent { get; }
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}