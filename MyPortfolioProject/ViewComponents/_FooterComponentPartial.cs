using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _FooterComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
    }
}
