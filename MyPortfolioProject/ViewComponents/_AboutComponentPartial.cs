using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _AboutComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.Take(1).FirstOrDefault();
            return View(value);
        }
    }
}
