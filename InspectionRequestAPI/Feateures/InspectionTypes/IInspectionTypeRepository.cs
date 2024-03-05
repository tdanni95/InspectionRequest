using InspectionRequestAPI.Entities;

namespace InspectionRequestAPI.Feateures.InspectionTypes;

public interface IInspectionTypeRepository
{
    Task<InspectionType?> GetById(Guid Id);
    Task<List<InspectionType>> GetAll();
}