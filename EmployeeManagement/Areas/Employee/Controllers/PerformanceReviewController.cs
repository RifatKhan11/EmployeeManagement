using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class PerformanceReviewController : Controller
    {
        public IActionResult PerformanceReview(int page = 1, int pageSize = 7)
        {
            return View();
        }
        public IActionResult SaveReview()
        {
            return View();
        }
        public IActionResult ShowReview()
        {
            return View();
        }
    }
}
