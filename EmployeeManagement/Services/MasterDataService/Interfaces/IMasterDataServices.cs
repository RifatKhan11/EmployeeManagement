using EmployeeManagement.Areas.MasterData.Models;
using EmployeeManagement.Data.Entity.MasterData;
namespace EmployeeManagement.Services.MasterDataServices.Interfaces
{
    public interface IMasterDataServices
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<IEnumerable<DepartmentModel>> GetAllAsync(int page, int pageSize);
        Task AddAsync(DepartmentInfo entity);
        Task UpdateAsync(DepartmentInfo entity);
        Task DeleteAsync(int id);
        Task<DepartmentInfo> GetByIdAsync(int id);
    }
}
