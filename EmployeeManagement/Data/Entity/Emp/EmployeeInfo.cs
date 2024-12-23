using EmployeeManagement.Data.Entity.MasterData;

namespace EmployeeManagement.Data.Entity.Emp
{
    public class EmployeeInfo: Base
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int? departmentId { get; set; }
        public DepartmentInfo department { get; set; }
        public string position { get; set; }
        public DateTime? joiningDate { get; set; }
    }
}
