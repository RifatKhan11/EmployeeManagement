using EmployeeManagement.Areas.Employee.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Data.Entity.Emp;
using EmployeeManagement.Services.Dapper.IInterfaces;
using EmployeeManagement.Services.EmployeeService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace EmployeeManagement.Services.EmployeeService
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDbContext _context;
        private readonly IDapper _dapper;

        public EmployeeServices(AppDbContext context, IDapper dapper)
        {
            _context = context;
            this._dapper = dapper;
        }

        public async Task<IEnumerable<EmployeeInfoModel>> GetAllAsync()
        {
            return await _context.Employees
               .Include(e => e.department).Where(x => x.isActive == true)
               .Select(e => new EmployeeInfoModel
               {
                   Id = e.Id,
                   name = e.name,
                   email = e.email,
                   phoneNumber = e.phoneNumber,
                   departmentId = e.departmentId,
                   department = e.department != null ? e.department.departmentName : null,
                   position = e.position,
                   joiningDate = e.joiningDate,

               }).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeInfoModel>> GetAllAsync(int page, int pageSize)
        {
            int count = await _context.Employees.Where(x => x.isActive == true).CountAsync();
            return await _context.Employees
       .Include(e => e.department).Where(x => x.isActive == true)
       .Select(e => new EmployeeInfoModel
       {
           Id = e.Id,
           name = e.name,
           email = e.email,
           phoneNumber = e.phoneNumber,
           departmentId = e.departmentId,
           department = e.department != null ? e.department.departmentName : null,
           position = e.position,
           joiningDate = e.joiningDate,
           CurrentPage = page,
           TotalRecords = count,
           PageSize = pageSize,
           TotalPages = (int)Math.Ceiling((double)count / pageSize)
       }).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<EmployeeInfo> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.department)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(EmployeeInfo employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeInfo employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.name = employee.name;
                existingEmployee.email = employee.email;
                existingEmployee.phoneNumber = employee.phoneNumber;
                existingEmployee.departmentId = employee.departmentId;
                existingEmployee.position = employee.position;
                existingEmployee.joiningDate = employee.joiningDate;
                existingEmployee.isActive = true;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee != null)
            {
                existingEmployee.isActive = false;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EmployeeSearchModel> GetEmployeeByFilter(string name, int deptId, string position, int score, int page, int pageSize)
        {

            EmployeeSearchModel employeeSearchModel = null;
            var data = await _dapper.FromSqlAsync<Sp_EmployeeSearchModel>($"Sp_GetEmployeInfo '{name}',{deptId},'{position}',{score}");

            employeeSearchModel.sp_EmployeeSearch = data;
            employeeSearchModel.CurrentPage = page;
            employeeSearchModel.TotalRecords = data.Count();
            employeeSearchModel.PageSize = pageSize;
            employeeSearchModel.TotalPages = (int)Math.Ceiling((double)data.Count() / pageSize);
            return employeeSearchModel;




        }
        public async Task<EmployeeSearchModel> GetScoreReport(int page, int pageSize)
        {

            EmployeeSearchModel employeeSearchModel = null;
            var data = await _dapper.FromSqlAsync<Sp_EmployeeSearchModel>($"Sp_GetEmployeInfo");

            employeeSearchModel.sp_EmployeeSearch = data;
            employeeSearchModel.CurrentPage = page;
            employeeSearchModel.TotalRecords = data.Count();
            employeeSearchModel.PageSize = pageSize;
            employeeSearchModel.TotalPages = (int)Math.Ceiling((double)data.Count() / pageSize);
            return employeeSearchModel;




        }
    }
}
