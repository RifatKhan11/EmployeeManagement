namespace EmployeeManagement.Data.Entity.Emp
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
