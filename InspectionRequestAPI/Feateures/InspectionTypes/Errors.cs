using ErrorOr;

namespace InspectionRequestAPI.Feateures.InspectionTypes;

public static partial class Errors
{
    public static class InspectionTypes
    {
        public static Error NotFound => Error.NotFound("InspectionType.NotFound", "Inspection type not found");
    }
}