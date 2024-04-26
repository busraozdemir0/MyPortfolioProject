using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents.AdminStatisticComponent
{
	public class _AdminStatisticFirst:ViewComponent
	{
		private readonly AppDbContext _context;

		public _AdminStatisticFirst(AppDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.skillCount = _context.Skills.Count();
			ViewBag.messageCount = _context.Messages.Count();
			ViewBag.falseMessageCount = _context.Messages.Where(x => x.IsRead == false).Count(); // Okunmayan mesaj sayisi
			ViewBag.trueMessageCount = _context.Messages.Where(x => x.IsRead == true).Count(); // Okunan mesaj sayisi
			
			return View();
		}
	}
}
