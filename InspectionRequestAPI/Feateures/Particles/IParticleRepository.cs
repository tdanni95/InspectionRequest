using InspectionRequestAPI.Entities;

namespace InspectionRequestAPI.Feateures.Particles;

public interface IParticleRepository
{
    Task<List<Particle>> GetAll();
    Task<Particle?> GetById(Guid Id);
    Task<Particle?> GetByName(string name);
    void Add(Particle particle);
}