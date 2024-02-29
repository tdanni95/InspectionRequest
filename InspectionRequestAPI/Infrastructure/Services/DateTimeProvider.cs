using InspectionRequestAPI.Common.Interfaces;

namespace InspectionRequestAPI.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}