using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Feateures.InspectionTypes;
using InspectionRequestAPI.Feateures.Particles;
using InspectionRequestAPI.Feateures.Tools;
using InspectionRequestAPI.Feateures.Users;
using InspectionRequestAPI.Infrastructure.Persistence;

namespace InspectionRequestAPI.Infrastructure;

public class UnitOfWork(
    InspectionRequestDbContext _dbContext,
    IUserRepository _userRepository,
    IParticleRepository _particleRepository,
    IToolRepository _toolRepository,
    IInspectionTypeRepository _inpsectionTypeRepository
): IUnitOfWork
{

    public IUserRepository UserRepository => _userRepository;

    public IParticleRepository ParticleRepository => _particleRepository;

    public IToolRepository ToolRepository => _toolRepository;

    public IInspectionTypeRepository InspectionTypeRepository => _inpsectionTypeRepository;

    public async Task<bool> Complete() => await _dbContext.SaveChangesAsync() > 0;

    public bool HasChanges() => _dbContext.ChangeTracker.HasChanges();
}