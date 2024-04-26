using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _StatisticComponentPartial:ViewComponent
    {
        // Ana sayfadaki istatistik kismi icin

        private readonly AppDbContext _context;

        public _StatisticComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.ExperienceCount = _context.Experiences.Count();
            ViewBag.SkillCount = _context.Skills.Count();
            ViewBag.PortfolioCount = _context.Portfolios.Count(); // Tamamlanan proje sayisi
            ViewBag.TestimonialCount = _context.Testimonials.Count();
            
            return View();
        }
    }
}
