using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")] // Bu tarz sayfalara erisim icin kullanicinin Admin yetkisinin olmasi lazim
    public class AboutController : Controller
	{
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			var about=_context.Abouts.FirstOrDefault();
			ViewBag.aboutId = about.Id;
			return View(about);
		}
		[HttpGet]
		public IActionResult Update(int aboutId)
		{
			var about = _context.Abouts.Find(aboutId);
            return View(about);
        }
        [HttpPost]
        public IActionResult Update(About about)
        {
            _context.Abouts.Update(about);
			_context.SaveChanges();
			return RedirectToAction("Index","About");
        }
    }
}
