using InspectionRequestAPI.Feateures.Users;

namespace InspectionRequestAPI.Common.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}