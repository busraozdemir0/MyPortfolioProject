using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _ContactComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var contact=_context.Contacts.FirstOrDefault();
            ViewBag.title = contact.Title;
            ViewBag.description = contact.Description;
            return View();
        }
    }
}
