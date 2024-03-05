using ErrorOr;

namespace InspectionRequestAPI.Feateures.Tools;

public static partial class Errors
{
    public static class Tools
    {
        public static Error NotFound => Error.NotFound("Tool.NotFound", "Tool with given id not found");
        public static Error NameTaken => Error.Conflict("Tool.NameTaken", "Tool with given name already exists");

        public static Error InspectionTypeNotFound => Error.NotFound("InspectionType.NotFound", "Inspection type not found");
    }
}