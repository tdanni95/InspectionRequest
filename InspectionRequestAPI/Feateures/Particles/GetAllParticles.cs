using ErrorOr;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Contracts.particles;
using InspectionRequestAPI.Entities;
using MapsterMapper;
using MediatR;

namespace InspectionRequestAPI.Feateures.Particles;

public record GetAllParticlesQuery() : IRequest<ErrorOr<List<ParticleResponse>>>;

public class GetAllParticlesQueryHandler(IMapper _mapper, IUnitOfWork _uow) : IRequestHandler<GetAllParticlesQuery, ErrorOr<List<ParticleResponse>>>
{
    public async Task<ErrorOr<List<ParticleResponse>>> Handle(GetAllParticlesQuery request, CancellationToken cancellationToken)
    {
        var particles = await _uow.ParticleRepository.GetAll();

        return _mapper.Map<List<ParticleResponse>>(particles);
    }
}
