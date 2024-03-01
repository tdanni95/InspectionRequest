
using System.Reflection;
using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Common.Models;
using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Entities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Infrastructure.Persistence;

public class InspectionRequestDbContext : DbContext
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IDomainEventService _domainEventService;
    private readonly ICurrentUserService _currentUserService;

    public InspectionRequestDbContext(DbContextOptions<InspectionRequestDbContext> options,
        IDateTimeProvider dateTimeProvider, IDomainEventService domainEventService, ICurrentUserService currentUserService)
        : base(options)
    {
        _dateTimeProvider = dateTimeProvider;
        _domainEventService = domainEventService;
        _currentUserService = currentUserService;
    }

    public DbSet<Attendance> attendances { get; set; }
    public DbSet<ChemicalInspection> chemicalInspections { get; set; }
    public DbSet<Examination> examinations { get; set; }
    public DbSet<Inspection> inspections { get; set; }
    public DbSet<InspectionRequest> inspectionRequests { get; set; }
    public DbSet<InspectionType> inspectionTypes { get; set; }
    public DbSet<MechanicalInspection> mechanicalInspections { get; set; }
    public DbSet<Particle> particles { get; set; }
    public DbSet<Tool> tools { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<BlockedTimes> blockedTimes { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.CurrentUser();
                    entry.Entity.Created = _dateTimeProvider.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.CreatedBy = _currentUserService.CurrentUser();
                    entry.Entity.Created = _dateTimeProvider.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    entry.Entity.Visible = false;
                    break;
                default:
                    break;
            }

        }

        var events = ChangeTracker.Entries<IHasDomainEvents>()
            .Select(x => x.Entity.DomainEvents)
            .SelectMany(x => x)
            .Where(domainEvent => !domainEvent.IsPublished)
            .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}