using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using MediatR;

namespace InspectionRequestAPI.Feateures.Particles;

public record UpdateParticleCommand(Guid Id, string Name, uint SizeInNm) : IRequest<ErrorOr<Updated>>;

public class UpdateParticleCommandValidator : AbstractValidator<UpdateParticleCommand>
{
    public UpdateParticleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.SizeInNm).NotEmpty();
    }
}

public class UpdateParticleCommandHandler(IUnitOfWork _uow) : IRequestHandler<UpdateParticleCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateParticleCommand request, CancellationToken cancellationToken)
    {
        var isParticle = await _uow.ParticleRepository.GetById(request.Id);
        if (isParticle is null) return Errors.Particles.NotFOund;

        var isNameTaken = await _uow.ParticleRepository.GetByName(request.Name);
        if (isNameTaken is not null && isNameTaken.Id != request.Id) return Errors.Particles.NameTaken;

        isParticle.Name = request.Name;
        isParticle.SizeInNm = request.SizeInNm;

        if (await _uow.Complete()) return Result.Updated;

        return Error.Failure();
    }
}
