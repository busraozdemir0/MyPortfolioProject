using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
	{       
        public IActionResult Index()
        {
            return View();
        }
    }
}
