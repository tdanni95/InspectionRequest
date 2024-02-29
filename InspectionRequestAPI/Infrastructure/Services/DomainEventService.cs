using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Common.Models;
using MediatR;

namespace InspectionRequestAPI.Infrastructure.Services;

public class DomainEventService : IDomainEventService
{
    private readonly ILogger<DomainEventService> _logger;
    private readonly IPublisher _publisher;
    public DomainEventService(ILogger<DomainEventService> logger, IPublisher publisher)
    {
        _logger = logger;
        _publisher = publisher;
    }
    public Task Publish(DomainEvent domainEvent)
    {
        _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
        return _publisher.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
    }

    private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
    {
        return (INotification)Activator.CreateInstance(
            typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
    }
}