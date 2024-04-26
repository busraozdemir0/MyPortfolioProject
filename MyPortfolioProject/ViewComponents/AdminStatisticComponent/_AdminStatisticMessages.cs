using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents.AdminStatisticComponent
{
	public class _AdminStatisticMessages:ViewComponent
	{
		private readonly AppDbContext _context;

		public _AdminStatisticMessages(AppDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var messages=_context.Messages.Where(x=>x.IsRead==false).ToList(); // Okunmamis mesajlar
			return View(messages);
		}
	}
}
