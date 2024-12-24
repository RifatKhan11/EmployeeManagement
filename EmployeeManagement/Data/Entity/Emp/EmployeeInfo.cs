using EmployeeManagement.Data.Entity.MasterData;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data.Entity.Emp
{
    public class EmployeeInfo: Base
    {
        [Column(TypeName = "NVARCHAR(200)")]
        public string name { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string email { get; set; }

        [Column(TypeName = "NVARCHAR(20)")]
        public string phoneNumber { get; set; }
        public int? departmentId { get; set; }
        public DepartmentInfo department { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string position { get; set; }
        public DateTime? joiningDate { get; set; }
    }
}
