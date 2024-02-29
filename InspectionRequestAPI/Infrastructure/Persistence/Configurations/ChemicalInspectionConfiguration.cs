using InspectionRequestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspectionRequestAPI.Infrastructure.Persistence.Configurations;

public class ChemicalInspectionConfiguration : IEntityTypeConfiguration<ChemicalInspection>
{
    public void Configure(EntityTypeBuilder<ChemicalInspection> builder)
    {
        
    }
}