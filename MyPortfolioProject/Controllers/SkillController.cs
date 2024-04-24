﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Skill skill)
		{
			_context.Skills.Add(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(int skillId)
		{
			var value = _context.Skills.Find(skillId);
			return View(value);
		}
		[HttpPost]
		public IActionResult Update(Skill skill)
		{
			_context.Skills.Update(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int skillId)
		{
			var value = _context.Skills.Find(skillId);
			_context.Skills.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
