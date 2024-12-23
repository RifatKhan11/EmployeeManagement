using EmployeeManagement.Data.Entity.Emp;

namespace EmployeeManagement.Data.Entity.MasterData
{
    public class DepartmentInfo: Base
    {
        public string departmentName { get; set; }
        public int? managerId { get; set; }
        public EmployeeInfo manager { get; set; }
        public decimal? budget { get; set; }
    }
}
