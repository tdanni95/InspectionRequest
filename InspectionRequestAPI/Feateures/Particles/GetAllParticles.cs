using ErrorOr;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Contracts.particles;
using InspectionRequestAPI.Entities;
using MapsterMapper;
using MediatR;

namespace InspectionRequestAPI.Feateures.Particles;

public record GetAllParticlesQuery() : IRequest<ErrorOr<List<Particle>>>;

public class GetAllParticlesQueryHandler(IUnitOfWork _uow) : IRequestHandler<GetAllParticlesQuery, ErrorOr<List<Particle>>>
{
    public async Task<ErrorOr<List<Particle>>> Handle(GetAllParticlesQuery request, CancellationToken cancellationToken) => await _uow.ParticleRepository.GetAll();
    
}
