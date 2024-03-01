using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Feateures.Users;
using InspectionRequestAPI.Infrastructure.Persistence;

namespace InspectionRequestAPI.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly InspectionRequestDbContext _dbContext;
    private readonly IUserRepository _userRepository;

    public UnitOfWork(InspectionRequestDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
    }

    public IUserRepository UserRepository => _userRepository;

    public async Task<bool> Complete() => await _dbContext.SaveChangesAsync() > 0;

    public bool HasChanges() => _dbContext.ChangeTracker.HasChanges();
}