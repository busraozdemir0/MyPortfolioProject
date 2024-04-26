using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.Controllers
{
    public class StatisticController : Controller
    {
        private readonly AppDbContext _context;

        public StatisticController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.skillCount = _context.Skills.Count();
            ViewBag.messageCount = _context.Messages.Count();
            ViewBag.falseMessageCount = _context.Messages.Where(x => x.IsRead == false).Count(); // Okunmayan mesaj sayisi
            ViewBag.trueMessageCount = _context.Messages.Where(x => x.IsRead == true).Count(); // Okunan mesaj sayisi
            return View();
        }
    }
}
