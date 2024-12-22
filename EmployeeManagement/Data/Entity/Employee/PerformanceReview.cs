namespace EmployeeManagement.Data.Entity.Employee
{
    public class PerformanceReview: Base
    {
        public int employeeId { get; set; }
        public EmployeeInfo employee { get; set; }
        public DateTime reviewDate { get; set; }
        public decimal score { get; set; }
        public string notes { get; set; }
    }
}
