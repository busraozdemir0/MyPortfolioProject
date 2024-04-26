using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _SkillComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _SkillComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
    }
}
