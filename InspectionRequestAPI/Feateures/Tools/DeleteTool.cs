using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Data;
using MediatR;

namespace InspectionRequestAPI.Feateures.Tools;

public record DeleteToolCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;

public class DeleteToolCommandValidator : AbstractValidator<DeleteToolCommand>
{
    public DeleteToolCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
    }
}

public class DeleteToolCommandHandler(IUnitOfWork _uow) : IRequestHandler<DeleteToolCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteToolCommand request, CancellationToken cancellationToken)
    {
        var isTool = await _uow.ToolRepository.GetById(request.Id);

        if (isTool is null) return Errors.Tools.NotFound;

        _uow.ToolRepository.Delete(isTool);

        if (await _uow.Complete()) return Result.Deleted;

        return Error.Failure();
    }
}
