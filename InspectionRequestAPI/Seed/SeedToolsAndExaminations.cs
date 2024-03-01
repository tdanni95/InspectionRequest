using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Seed;

public class SeedToolsAndExaminations
{
    public static async Task Seed(InspectionRequestDbContext dbContext)
    {
        if (await dbContext.tools.AnyAsync() || await dbContext.inspections.AnyAsync()) return;

        List<string> newChemistryTools = new List<string> { "Mass Spectrometer", "pH Meter", "Atomic Absorption Spectrometer", "Karl Fischer Titrator", "High-Performance Liquid Chromatograph (HPLC)" };
        List<string> newChemistryExaminations = new List<string> { "Elemental Analysis", "pH Measurement", "Purity Testing", "Titration Analysis", "Chromatographic Separation" };

        var chemistryInspectionType = new InspectionType { Id = Guid.NewGuid(), Name = "Chemical inspection" };

        for (int i = 0; i < newChemistryTools.Count; i++)
        {
            var tool = new Tool { Id = Guid.NewGuid(), Name = newChemistryTools[i], UsedForType = chemistryInspectionType };
            var examination = new Examination { Id = Guid.NewGuid(), Name = newChemistryExaminations[i], ToolUsedToPerform = tool };

            dbContext.tools.Add(tool);
            dbContext.examinations.Add(examination);
        }


        List<string> newMechanicalTools = new List<string> { "Coordinate Measuring Machine (CMM)", "Hardness Tester", "Impact Tester", "Torque Wrench", "Surface Roughness Tester" };
        List<string> newMechanicalExaminations = new List<string> { "Dimensional Measurement", "Hardness Testing", "Impact Strength Testing", "Torque Verification", "Surface Finish Analysis" };

        var mechanicalInspectionType = new InspectionType { Id = Guid.NewGuid(), Name = "Mechanical inspection" };

        for (int i = 0; i < newMechanicalTools.Count; i++)
        {
            var tool = new Tool { Id = Guid.NewGuid(), Name = newMechanicalTools[i], UsedForType = mechanicalInspectionType };
            var examination = new Examination { Id = Guid.NewGuid(), Name = newMechanicalExaminations[i], ToolUsedToPerform = tool };

            dbContext.tools.Add(tool);
            dbContext.examinations.Add(examination);
        }

        await dbContext.SaveChangesAsync();
    }
}