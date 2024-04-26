using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _PortfolioComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _PortfolioComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var portfolios = _context.Portfolios.Include(i => i.Image).ToList();
            return View(portfolios);
        }
    }
}
