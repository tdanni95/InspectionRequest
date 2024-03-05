using InspectionRequestAPI.Entities;

namespace InspectionRequestAPI.Feateures.Tools;

public interface IToolRepository
{
    Task<List<Tool>> GetAll();
    void Add(Tool tool);
    Task<Tool?> GetById(Guid id);
    Task<Tool?> GetByName(string name);
    void Delete(Tool tool);
}