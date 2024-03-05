using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Feateures.Particles;
using InspectionRequestAPI.Feateures.Users;
using InspectionRequestAPI.Infrastructure.Persistence;

namespace InspectionRequestAPI.Infrastructure;

public class UnitOfWork(InspectionRequestDbContext _dbContext, IUserRepository _userRepository, IParticleRepository _particleRepository) : IUnitOfWork
{

    public IUserRepository UserRepository => _userRepository;

    public IParticleRepository ParticleRepository => _particleRepository;

    public async Task<bool> Complete() => await _dbContext.SaveChangesAsync() > 0;

    public bool HasChanges() => _dbContext.ChangeTracker.HasChanges();
}