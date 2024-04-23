using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
    public class FeatureController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            // Ana sayfada one cikan alan yazisi icin
            var feature = _context.Features.FirstOrDefault();
            ViewBag.featureId = feature.Id;
            return View(feature);
        }
        [HttpGet]
        public IActionResult Update(int featureId)
        {
            var feature = _context.Features.Find(featureId);
            return View(feature);
        }
        [HttpPost]
        public IActionResult Update(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return RedirectToAction("Index", "Feature");
        }
    }
}
