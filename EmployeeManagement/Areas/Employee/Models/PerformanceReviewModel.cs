using EmployeeManagement.Data.Entity.Emp;

namespace EmployeeManagement.Areas.Employee.Models
{
    public class PerformanceReviewModel
    {
        public int Id { get; set; }
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public DateTime reviewDate { get; set; }
        public decimal score { get; set; }
        public string notes { get; set; }
        public string dept { get; set; }


        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
