using ErrorOr;
using InspectionRequestAPI.Common.Data;
using InspectionRequestAPI.Entities;
using MediatR;

namespace InspectionRequestAPI.Feateures.Tools;

public record GetAllToolsQuery() : IRequest<ErrorOr<List<Tool>>>;

public class GetAllToolsQueryHandler(IUnitOfWork _uow) : IRequestHandler<GetAllToolsQuery, ErrorOr<List<Tool>>>
{
    public async Task<ErrorOr<List<Tool>>> Handle(GetAllToolsQuery request, CancellationToken cancellationToken) => await _uow.ToolRepository.GetAll();
}
