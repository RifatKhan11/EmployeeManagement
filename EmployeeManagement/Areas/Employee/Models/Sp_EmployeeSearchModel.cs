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
        public int? countRow { get; set; }
        public decimal? score { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string departmentName { get; set; }
        public string position { get; set; }
        public DateTime? joiningDate { get; set; }
    }
}
