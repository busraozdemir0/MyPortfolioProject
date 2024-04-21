using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult ExperienceList()
        {
            return View();
        }
    }
}
