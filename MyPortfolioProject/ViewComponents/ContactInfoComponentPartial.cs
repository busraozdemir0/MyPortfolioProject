using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class ContactInfoComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public ContactInfoComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var contact = _context.Contacts.FirstOrDefault();
            return View(contact);
        }
    }
}
