using EmployeeManagement.Areas.MasterData.Models;
using EmployeeManagement.Data.Entity.MasterData;

namespace EmployeeManagement.Areas.EmployeeInfo.Models
{
    public class EmployeeInfoModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int? departmentId { get; set; }
        public DepartmentInfo department { get; set; }
        public string position { get; set; }
        public DateTime? joiningDate { get; set; }

        public IEnumerable<EmployeeInfoModel> employeeList { get; set; }
        public EmployeeInfoModel employeeInfo { get; set; }

        public IEnumerable<DepartmentModel> deptList { get; set; }
    }
}
