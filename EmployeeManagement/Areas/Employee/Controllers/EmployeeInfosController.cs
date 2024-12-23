using EmployeeManagement.Areas.Employee.Models;
using EmployeeManagement.Data.Entity.Emp;
using EmployeeManagement.Services.EmployeeService.Interfaces;
using EmployeeManagement.Services.MasterDataServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeInfosController : Controller
    {
        private readonly IEmployeeServices _employeeRepository;
        private readonly IMasterDataServices _iMasterDataServices;

        public EmployeeInfosController(IEmployeeServices employeeRepository, IMasterDataServices iMasterDataServices)
        {
            _employeeRepository = employeeRepository;
            _iMasterDataServices = iMasterDataServices;
        }
        public async Task<IActionResult> CreateEmployee(int page = 1, int pageSize = 7)
        {
            var employees = await _employeeRepository.GetAllAsync(page, pageSize);
            EmployeeInfoModel model= new EmployeeInfoModel();
            model.employeeList = employees;
            model.deptList = await _iMasterDataServices.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployee(EmployeeInfo employee)
        {
            if (employee.Id == 0)
            {
                await _employeeRepository.AddAsync(employee);
            }
            else
            {
                await _employeeRepository.UpdateAsync(employee);
            }
            return RedirectToAction("CreateEmployee");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            return RedirectToAction("CreateEmployee");
        }
        public async Task<JsonResult> GetEmployeeInfo(int Id)
        {
            var data=await _employeeRepository.GetByIdAsync(Id);
            return Json(data);
        }

        public async Task<IActionResult> SearchEmployeeView()
        {
            EmployeeInfoModel model = new EmployeeInfoModel();
            model.deptList = await _iMasterDataServices.GetAllAsync();

            return View(model);
        }
        public async Task<IActionResult> SearchEmployeePartial(string name,int deptId,string position,int score,int page = 1, int pageSize = 10)
        {
            var employees = await _employeeRepository.GetEmployeeByFilter(name, deptId, position, score, page, pageSize);
            EmployeeSearchModel model = new EmployeeSearchModel();
            model.employeeSearch = employees;

            return PartialView("_EmployeePartial", model);
        }

    }
}
