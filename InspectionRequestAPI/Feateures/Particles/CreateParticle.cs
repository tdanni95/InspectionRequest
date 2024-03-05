using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Entities;
using MediatR;

namespace InspectionRequestAPI.Feateures.Particles;

public record CreateParticleCommand(string Name, uint SizeInNm) : IRequest<ErrorOr<Guid>>;

public class CreateParticleCommandValidator : AbstractValidator<CreateParticleCommand>
{
    public CreateParticleCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.SizeInNm).NotEmpty();
    }
}

public class CreateParticleCommandHandler(IUnitOfWork _uow) : IRequestHandler<CreateParticleCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateParticleCommand request, CancellationToken cancellationToken)
    {
        var particle = new Particle { Name = request.Name, SizeInNm = request.SizeInNm, Id = Guid.NewGuid() };

        var isParticle = await _uow.ParticleRepository.GetByName(request.Name);

        if(isParticle is not null) return Errors.Particles.NameTaken;

        _uow.ParticleRepository.Add(particle);

        if(await _uow.Complete()) return particle.Id;

        return Errors.Particles.FailedToCreate;
    }
}