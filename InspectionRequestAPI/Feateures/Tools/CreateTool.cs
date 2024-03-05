using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Entities;
using MediatR;

namespace InspectionRequestAPI.Feateures.Tools;

public record CreateToolCommand(string Name, Guid InspectionTypeId) : IRequest<ErrorOr<Guid>>;

public class CreateToolCommandValidator : AbstractValidator<CreateToolCommand>
{
    public CreateToolCommandValidator()
    {
        RuleFor(t => t.Name).NotEmpty();
        RuleFor(t => t.InspectionTypeId).NotEmpty();
    }
}

public class CreateToolCommandHandler(IUnitOfWork _uow) : IRequestHandler<CreateToolCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateToolCommand request, CancellationToken cancellationToken)
    {
        var isNameTaken = await _uow.ToolRepository.GetByName(request.Name);

        if (isNameTaken is not null) return Errors.Tools.NameTaken;

        var inspectionType = await _uow.InspectionTypeRepository.GetById(request.InspectionTypeId);

        if (inspectionType is null) return Errors.Tools.InspectionTypeNotFound;

        var newTool = new Tool { Id = Guid.NewGuid(), Name = request.Name, UsedForType = inspectionType };

        _uow.ToolRepository.Add(newTool);

        if(await _uow.Complete()) return newTool.Id;

        return Error.Failure();
    }
}
