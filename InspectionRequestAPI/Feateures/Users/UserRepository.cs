using ErrorOr;
using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Feateures.Users;

public class UserRepository : IUserRepository
{
    private readonly InspectionRequestDbContext _dbContext;

    public UserRepository(InspectionRequestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ErrorOr<bool>> GrantRole(string username, string rolename)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsUserNameTaken(string username)
    {
        return await GetByUsername(username) is not null;
    }


    public void Add(User user)
    {
        _dbContext.users.Add(user);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _dbContext.users.FirstOrDefaultAsync(u => u.Login == username);
    }

    public async Task<User?> GetByRefreshToken(string token)
    {
        return await _dbContext.users.FirstOrDefaultAsync(u => u.RefreshToken.Token == token);
    }
}