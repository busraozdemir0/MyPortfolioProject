using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.Controllers
{
    public class StatisticController : Controller
	{       
        public IActionResult Index()
        {
            return View();
        }
    }
}
