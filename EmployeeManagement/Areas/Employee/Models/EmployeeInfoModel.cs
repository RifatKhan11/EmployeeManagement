
using EmployeeManagement.Areas.MasterData.Models;

namespace EmployeeManagement.Areas.Employee.Models
{
    public class EmployeeInfoModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int? departmentId { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public DateTime? joiningDate { get; set; }

        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public IEnumerable<EmployeeInfoModel> employeeList { get; set; }
        public EmployeeInfoModel employeeInfo { get; set; }

        public IEnumerable<DepartmentModel> deptList { get; set; }
    }
}
