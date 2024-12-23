namespace EmployeeManagement.Areas.Employee.Models
{
    public class EmployeeSearchModel
    {
        public IEnumerable<Sp_EmployeeSearchModel> sp_EmployeeSearch { get; set; }
        public EmployeeSearchModel employeeSearch { get; set; }


        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
    }
    public class Sp_EmployeeSearchModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int? departmentId { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public DateTime? joiningDate { get; set; }
    }
}
