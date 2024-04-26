using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _TestimonialComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
