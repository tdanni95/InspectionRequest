using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Feateures.Particles;

public class ParticleRepository(InspectionRequestDbContext _dbContext) : IParticleRepository
{
    public async Task<List<Particle>> GetAll() => await _dbContext.particles.AsNoTracking().OrderBy(p => p.Name).ToListAsync();
    public async Task<Particle?> GetById(Guid Id) => await _dbContext.particles.FirstOrDefaultAsync(p => p.Id == Id);
    public void Add(Particle particle) => _dbContext.particles.Add(particle);

    public async Task<Particle?> GetByName(string name) => await _dbContext.particles.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());

    public void Delete(Particle particle) => _dbContext.particles.Remove(particle);
}