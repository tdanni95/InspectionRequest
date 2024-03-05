using InspectionRequestAPI.Feateures.InspectionTypes;
using InspectionRequestAPI.Feateures.Particles;
using InspectionRequestAPI.Feateures.Tools;
using InspectionRequestAPI.Feateures.Users;

namespace InspectionRequestAPI.Common.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IParticleRepository ParticleRepository { get; }
    IToolRepository ToolRepository { get; }
    IInspectionTypeRepository InspectionTypeRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}