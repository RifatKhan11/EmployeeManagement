using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.MasterData.Controllers
{
    public class MasterDataController : Controller
    {
        [HttpGet]
        public IActionResult DepartmentInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveDepartment()
        {

            return Json(true);
        }


    }
}
