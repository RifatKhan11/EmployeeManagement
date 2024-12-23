using EmployeeManagement.Areas.Employee.Models;
using EmployeeManagement.Data.Entity.Emp;

namespace EmployeeManagement.Services.EmployeeService.Interfaces
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<EmployeeInfoModel>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<EmployeeInfo> GetByIdAsync(int id);
        Task AddAsync(EmployeeInfo employee);
        Task UpdateAsync(EmployeeInfo employee);
        Task DeleteAsync(int id);
        Task<EmployeeSearchModel> GetEmployeeByFilter(string name, int deptId, string position, int score, int page, int pageSize);
        Task<EmployeeSearchModel> GetScoreReport(int page, int pageSize);
    }
}
