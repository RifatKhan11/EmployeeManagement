using EmployeeManagement.Areas.MasterData.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Data.Entity.Emp;
using EmployeeManagement.Data.Entity.MasterData;
using EmployeeManagement.Services.MasterDataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services.MasterDataService
{
    public class MasterDataServices: IMasterDataServices
    {
        private AppDbContext _dbContext;
        public MasterDataServices(AppDbContext dbContext)
        {
                this._dbContext = dbContext;
        }

        public async Task AddAsync(DepartmentInfo dept)
        {
            await _dbContext.Departments.AddAsync(dept);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dept = await _dbContext.Departments.FindAsync(id);
            if (dept != null)
            {
                dept.isActive = false;
                _dbContext.Departments.Update(dept);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<DepartmentInfo> GetByIdAsync(int id)
        {
            return await _dbContext.Departments
                .Include(e => e.manager).AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<IEnumerable<DepartmentModel>> GetAllAsync(int page, int pageSize)
        {
            int count = await _dbContext.Departments.CountAsync(x => x.isActive == true);

            var departments = await _dbContext.Departments
                .Where(x => x.isActive == true)
                .Include(x => x.manager)
                .OrderBy(x => x.Id) // Order the data for consistent pagination
                .Skip((page - 1) * pageSize) // Skip the records of previous pages
                .Take(pageSize) // Take only the records for the current page
                .Select(x => new DepartmentModel
                {
                    Id = x.Id,
                    departmentName = x.departmentName,
                    managerId = x.managerId,
                    budget = x.budget,
                    managerName = x.manager.name,
                    CurrentPage = page,
                    TotalRecords = count,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)count / pageSize)
                }).OrderByDescending(x => x.Id)
                .ToListAsync();

            return departments;
        }
        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {

            return await _dbContext.Departments
            .Where(x=>x.isActive == true)
            .Select(x=> new DepartmentModel
            {
                Id= x.Id,
                departmentName=x.departmentName,
                managerId=x.managerId,
                budget=x.budget,               

            }).ToListAsync();
        }

        public async Task UpdateAsync(DepartmentInfo entity)
        {
            var dept = await _dbContext.Departments.FindAsync(entity.Id);
            if (dept != null)
            {
                dept.departmentName = entity.departmentName;
                dept.managerId = entity.managerId;              
                dept.budget = entity.budget;

                _dbContext.Departments.Update(dept);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
