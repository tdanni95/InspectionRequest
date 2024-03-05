namespace InspectionRequestAPI.Contracts.tools;

public record ToolResponse(Guid Id, string Name, ToolUsedForType UsedForType);

public record ToolUsedForType(Guid Id, string Name);