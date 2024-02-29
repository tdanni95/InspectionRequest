using InspectionRequestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspectionRequestAPI.Infrastructure.Persistence.Configurations;

public class MechanicalInspectionConfiguration : IEntityTypeConfiguration<MechanicalInspection>
{
    public void Configure(EntityTypeBuilder<MechanicalInspection> builder)
    {
       
    }
}