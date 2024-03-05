namespace InspectionRequestAPI.Contracts.tools;

public record UpdateToolRequest(Guid Id, string Name, Guid InspectionTypeId);