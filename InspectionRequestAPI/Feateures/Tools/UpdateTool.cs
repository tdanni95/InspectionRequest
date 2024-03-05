using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using MediatR;

namespace InspectionRequestAPI.Feateures.Tools;

public record UpdateToolCommand(Guid Id, string Name, Guid InspectionTypeId) : IRequest<ErrorOr<Updated>>;

public class UpdateToolCommandValidator : AbstractValidator<UpdateToolCommand>
{
    public UpdateToolCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
        RuleFor(t => t.Name).NotEmpty();
        RuleFor(t => t.InspectionTypeId).NotEmpty();
    }
}

public class UpdateToolCommandHandler(IUnitOfWork _uow) : IRequestHandler<UpdateToolCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateToolCommand request, CancellationToken cancellationToken)
    {
        var isTool = await _uow.ToolRepository.GetById(request.Id);
        if (isTool is null) return Errors.Tools.NotFound;

        var isNameTaken = await _uow.ToolRepository.GetByName(request.Name);
        if (isNameTaken is not null && isNameTaken.Id != request.Id) return Errors.Tools.NameTaken;

        var inspectionType = await _uow.InspectionTypeRepository.GetById(request.InspectionTypeId);
        if (inspectionType is null) return Errors.Tools.InspectionTypeNotFound;

        isTool.Name = request.Name;
        isTool.UsedForType = inspectionType;

        if(await _uow.Complete()) return Result.Updated;

        return Error.Failure();
    }
}
