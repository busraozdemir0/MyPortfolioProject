using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contact = _context.Contacts.FirstOrDefault();
            ViewBag.contactId = contact.Id;
            return View(contact);
        }
        [HttpGet]
        public IActionResult Update(int contactId)
        {
            var contact = _context.Contacts.Find(contactId);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }
    }
}
