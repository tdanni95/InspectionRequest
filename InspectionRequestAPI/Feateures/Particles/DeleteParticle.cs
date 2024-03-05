using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using MediatR;

namespace InspectionRequestAPI.Feateures.Particles;

public record DeleteParticleCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;

public class DeleteParticleCommandValidator : AbstractValidator<DeleteParticleCommand>
{
    public DeleteParticleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}

public class DeleteParticleCommandHandler(IUnitOfWork _uow) : IRequestHandler<DeleteParticleCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteParticleCommand request, CancellationToken cancellationToken)
    {
        var isParticle = await _uow.ParticleRepository.GetById(request.Id);
        if (isParticle is null) return Errors.Particles.NotFOund;

        _uow.ParticleRepository.Delete(isParticle);

        if (await _uow.Complete()) return Result.Deleted;

        return Error.Failure();
    }
}
