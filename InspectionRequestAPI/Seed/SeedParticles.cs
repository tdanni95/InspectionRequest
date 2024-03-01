using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Seed;

public static class SeedParticles
{
    public static async Task Seed(InspectionRequestDbContext dbContext)
    {

        if (await dbContext.particles.AnyAsync()) return;

        var newParticles = new List<string> { "Sodium chloride (NaCl)", "Calcium carbonate (CaCO3)", "Iron oxide (Fe2O3)",
        "Silicon dioxide (SiO2)", "Potassium nitrate (KNO3)", "Magnesium sulfate (MgSO4)",
        "Aluminum hydroxide (Al(OH)3)", "Copper sulfate (CuSO4)", "Zinc oxide (ZnO)",
        "Silver chloride (AgCl)", "Barium sulfate (BaSO4)", "Lead carbonate (PbCO3)",
        "Nickel oxide (NiO)", "Titanium dioxide (TiO2)", "Mercury sulfide (HgS)", "Chromium oxide (Cr2O3)", "Cobalt carbonate (CoCO3)",
        "Manganese dioxide (MnO2)", "Cadmium sulfide (CdS)", "Bismuth nitrate (Bi(NO3)3)" };

        var sizes = new List<uint> { 100, 75, 200, 50, 150, 80, 120, 180, 60, 90, 250, 40, 300, 70, 130, 220, 55, 85, 170, 110 };

        for (int i = 0; i < newParticles.Count; i++)
        {
            var p = new Particle { Id = Guid.NewGuid(), Name = newParticles[i], SizeInNm = sizes[i] };
            dbContext.particles.Add(p);
        }

        await dbContext.SaveChangesAsync();

    }
}