using EmployeeManagement.Areas.Employee.Models;
using EmployeeManagement.Data.Entity.Emp;

namespace EmployeeManagement.Areas.MasterData.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string departmentName { get; set; }
        public string managerName { get; set; }
        public int? managerId { get; set; }
        public decimal? budget { get; set; }
        public IEnumerable<EmployeeInfoModel> employeeList { get; set; }
        public IEnumerable<DepartmentModel> deptList { get; set; }



        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
