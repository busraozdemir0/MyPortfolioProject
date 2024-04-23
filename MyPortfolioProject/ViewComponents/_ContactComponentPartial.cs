﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        AppDbContext _context = new AppDbContext();
        public IViewComponentResult Invoke()
        {
            var contact=_context.Contacts.FirstOrDefault();
            ViewBag.title = contact.Title;
            ViewBag.description = contact.Description;
            return View();
        }
    }
}
