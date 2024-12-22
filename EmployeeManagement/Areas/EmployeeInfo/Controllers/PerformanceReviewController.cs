using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Areas.EmployeeInfo.Controllers
{
    [Area("EmployeeInfo")]
    public class PerformanceReviewController : Controller
    {
        public IActionResult PerformanceReview()
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
