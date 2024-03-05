namespace InspectionRequestAPI.Contracts.particles;

public record UpdateParticleRequest(Guid Id, string Name, uint SizeInNm);