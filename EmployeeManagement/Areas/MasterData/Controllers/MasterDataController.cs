using EmployeeManagement.Areas.MasterData.Models;
using EmployeeManagement.Data.Entity.MasterData;
using EmployeeManagement.Services.EmployeeService.Interfaces;
using EmployeeManagement.Services.MasterDataServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.MasterData.Controllers
{
    [Area("MasterData")]
    public class MasterDataController : Controller
    {
        private readonly IEmployeeServices _employeeRepository;
        private readonly IMasterDataServices _iMasterDataServices;
        public MasterDataController(IEmployeeServices employeeRepository, IMasterDataServices iMasterDataServices)
        {
            _employeeRepository = employeeRepository;
            _iMasterDataServices = iMasterDataServices;
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentInfo(int page = 1, int pageSize = 7)
        {
            var departmentModels = await _iMasterDataServices.GetAllAsync(page, pageSize);

            var model = new DepartmentModel
            {
                deptList = departmentModels.ToList(),
                employeeList = await _employeeRepository.GetAllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDepartment(DepartmentInfo dept)
        {

            if (dept.Id == 0)
            {
                await _iMasterDataServices.AddAsync(dept);
            }
            else
            {
                await _iMasterDataServices.UpdateAsync(dept);
            }
            return RedirectToAction("DepartmentInfo");
        }


        public async Task<JsonResult> GetdeptInfo(int Id)
        {
            var data = await _iMasterDataServices.GetByIdAsync(Id);
            return Json(data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _iMasterDataServices.DeleteAsync(id);
            return RedirectToAction("DepartmentInfo");
        }

    }
}
