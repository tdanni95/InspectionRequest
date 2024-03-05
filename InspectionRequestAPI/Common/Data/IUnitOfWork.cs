using InspectionRequestAPI.Feateures.Particles;
using InspectionRequestAPI.Feateures.Users;

namespace InspectionRequestAPI.Common.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IParticleRepository ParticleRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}