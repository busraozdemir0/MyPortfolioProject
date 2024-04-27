using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
	{
        private readonly AppDbContext _context;

        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			var values=_context.Testimonials.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Testimonial testimonial)
		{
			_context.Testimonials.Add(testimonial);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(int testimonialId)
		{
			var value = _context.Testimonials.Find(testimonialId);
			return View(value);
		}
		[HttpPost]
		public IActionResult Update(Testimonial testimonial)
		{
			_context.Testimonials.Update(testimonial);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int testimonialId)
		{
			var value = _context.Testimonials.Find(testimonialId);
			_context.Testimonials.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
