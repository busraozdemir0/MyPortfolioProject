﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
	public class MessageController : Controller
	{
		AppDbContext _context = new AppDbContext();
		public IActionResult Inbox()
		{
			var values = _context.Messages.ToList();
			return View(values);
		}

		public IActionResult ChangeIsReadToTrue(int id) // Mesaji okundu olarak isaretlemek icin
		{
			var value = _context.Messages.Find(id);
			value.IsRead = true;
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult ChangeIsReadToFalse(int id) // Mesaji okunmadi olarak isaretlemek icin
		{
			var value = _context.Messages.Find(id);
			value.IsRead = false;
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult DeleteMessage(int id)
		{
			var value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult MessageDetail(int id)
		{
			var value = _context.Messages.Find(id);
			return View(value);
		}
		[HttpGet]
        public IActionResult SendMessage()
        {
            return View("~/Views/Shared/Components/_ContactComponentPartial/Default.cshtml");
        }
        [HttpPost]
		public IActionResult SendMessage(Message message) // Ana sayfadan gelen mesajlarin gonderimi
		{
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                message.IsRead = false;
                _context.Messages.Add(message);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
