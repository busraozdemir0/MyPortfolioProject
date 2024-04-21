using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
