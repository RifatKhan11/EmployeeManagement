using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.EmployeeInfo.Controllers
{
    [Area("EmployeeInfo")]
    public class EmployeeInfosController : Controller
    {
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveEmployee()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmpoyee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteEmpoyee()
        {
            return View();
        }
    }
}
