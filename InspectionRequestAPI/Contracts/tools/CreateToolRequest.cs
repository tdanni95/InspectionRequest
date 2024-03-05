namespace InspectionRequestAPI.Contracts.tools;

public record CreateToolRequest(string Name, Guid InspectionTypeId);