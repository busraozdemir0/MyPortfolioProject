using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
