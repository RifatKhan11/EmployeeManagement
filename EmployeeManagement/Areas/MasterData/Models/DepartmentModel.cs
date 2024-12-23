using EmployeeManagement.Areas.EmployeeInfo.Models;
using EmployeeManagement.Data.Entity.Emp;

namespace EmployeeManagement.Areas.MasterData.Models
{
    public class DepartmentModel
    {
        public string departmentName { get; set; }
        public int? managerId { get; set; }
        public decimal? budget { get; set; }
        public IEnumerable<EmployeeInfoModel> employeeList { get; set; }
        public IEnumerable<DepartmentModel> deptList { get; set; }
    }
}
