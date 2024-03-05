using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Feateures.Tools;

public class ToolRepository(InspectionRequestDbContext _dbContext) : IToolRepository
{
    public void Add(Tool tool)
    {
        _dbContext.tools.Add(tool);
    }

    public void Delete(Tool tool)
    {
        _dbContext.tools.Remove(tool);
    }

    public async Task<List<Tool>> GetAll() => await _dbContext.tools.AsNoTracking().Include(t => t.UsedForType).OrderBy(t => t.Name).ToListAsync();

    public async Task<Tool?> GetById(Guid id) => await _dbContext.tools.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<Tool?> GetByName(string name) => await _dbContext.tools.FirstOrDefaultAsync(t => t.Name == name);
}