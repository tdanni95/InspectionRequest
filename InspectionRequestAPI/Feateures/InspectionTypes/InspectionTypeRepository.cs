using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Feateures.InspectionTypes;

public class InspectionTypeRepository(InspectionRequestDbContext _dbContext) : IInspectionTypeRepository
{
    public async Task<List<InspectionType>> GetAll() => await _dbContext.inspectionTypes.AsNoTracking().OrderBy(i => i.Name).ToListAsync();

    public async Task<InspectionType?> GetById(Guid Id) => await _dbContext.inspectionTypes.FirstOrDefaultAsync(i => i.Id == Id);
}