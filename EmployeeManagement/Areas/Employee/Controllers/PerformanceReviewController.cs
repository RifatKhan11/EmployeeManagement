using EmployeeManagement.Areas.Employee.Models;
using EmployeeManagement.Data.Entity.Emp;
using EmployeeManagement.Services.EmployeeService.Interfaces;
using EmployeeManagement.Services.MasterDataServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class PerformanceReviewController : Controller
    {
        private readonly IEmployeeServices _employeeRepository;
        private readonly IMasterDataServices _iMasterDataServices;

        public PerformanceReviewController(IEmployeeServices employeeRepository, IMasterDataServices iMasterDataServices)
        {
            _employeeRepository = employeeRepository;
            _iMasterDataServices = iMasterDataServices;
        }
        public async Task<IActionResult> PerformanceReview(int page = 1, int pageSize = 7)
        {
            var perform = await _employeeRepository.GetAllPerformanceAsync(page, pageSize);
            EmployeeInfoModel model = new EmployeeInfoModel();
            model.PerformanceList = perform;
            model.employeeList = await _employeeRepository.GetAllAsync();

            return View(model);
        }
        public async Task<IActionResult> SaveReview(PerformanceReview model)
        {
            if (model.Id == 0)
            {
                await _employeeRepository.AddPerformanceAsync(model);
            }
            else
            {
                await _employeeRepository.UpdatePerformanceAsync(model);
            }
            return RedirectToAction("PerformanceReview");
        }

        public async Task<JsonResult> GetPerformance(int Id)
        {
            var data = await _employeeRepository.GetAllPerformanceAsync(Id);
            return Json(data);
        }
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _employeeRepository.DeleteReview(id);
            return RedirectToAction("PerformanceReview");
        }
    }
}
