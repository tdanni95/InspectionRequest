using InspectionRequestAPI.Common.Interfaces;

namespace InspectionRequestAPI.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    public Guid CurrentUser()
    {
        //TODO 
        return Guid.NewGuid();
    }
}