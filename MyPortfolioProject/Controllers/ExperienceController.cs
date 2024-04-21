﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
    public class ExperienceController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }
		[HttpPost]
		public IActionResult CreateExperience(Experience experience)
		{
            _context.Experiences.Add(experience);
            _context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}
		[HttpGet]
		public IActionResult UpdateExperience(int id)
		{
			var value = _context.Experiences.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateExperience(Experience experience)
		{
            _context.Experiences.Update(experience);
			_context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}

		public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            _context.Experiences.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
	}
}
