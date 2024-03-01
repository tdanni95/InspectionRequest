using ErrorOr;
using InspectionRequestAPI.Entities;

namespace InspectionRequestAPI.Feateures.Users;

public interface IUserRepository
{
    Task<bool> IsUserNameTaken(string username);
    void Add(User user);
    Task<ErrorOr<bool>> GrantRole(string username, string rolename);
    Task<User?> GetByUsername(string username);
}
