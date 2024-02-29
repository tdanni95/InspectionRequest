
using System.Reflection;
using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Entities.Helpers;
using InspectionRequestAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Infrastructure.Persistence;

public class InspectionRequestDbContext : DbContext
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ICurrentUserService _currentUserService;

    public InspectionRequestDbContext(DbContextOptions<InspectionRequestDbContext> options,
        IDateTimeProvider dateTimeProvider, ICurrentUserService currentUserService)
        : base(options)
    {
        _dateTimeProvider = dateTimeProvider;
        _currentUserService = currentUserService;
    }

    public DbSet<Attendance> attendances { get; set; }
    public DbSet<ChemicalInspection> chemicalInspections { get; set; }
    public DbSet<Inspection> inspections { get; set; }
    public DbSet<InspectionRequest> inspectionRequests { get; set; }
    public DbSet<InspectionType> inspectionTypes { get; set; }
    public DbSet<MechanicalInspection> mechanicalInspections { get; set; }
    public DbSet<Particle> particles { get; set; }
    public DbSet<Tool> tools { get; set; }
    public DbSet<User> users { get; set; }

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

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}