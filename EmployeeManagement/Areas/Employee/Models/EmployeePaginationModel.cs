namespace EmployeeManagement.Areas.Employee.Models
{
    public class EmployeePaginationModel
    {
        public IEnumerable<Sp_EmployeeSearchModel> employeeList { get; set; }
        #region For Pagination
        public int? TotalPages { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int? totalItems { get; set; }
        #endregion
    }
}
