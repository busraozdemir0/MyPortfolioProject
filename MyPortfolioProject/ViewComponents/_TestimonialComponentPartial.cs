using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        AppDbContext _context = new AppDbContext();
        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
