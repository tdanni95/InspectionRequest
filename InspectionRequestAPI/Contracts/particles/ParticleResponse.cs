namespace InspectionRequestAPI.Contracts.particles;

public class ParticleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public uint SizeInNm { get; set; }
}