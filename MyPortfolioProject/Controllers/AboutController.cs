using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
	public class AboutController : Controller
	{
		AppDbContext _context = new AppDbContext();
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
