using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
	public class FeatureSocialMedia:ViewComponent
	{
		AppDbContext _context = new AppDbContext();
		public IViewComponentResult Invoke()
		{
			var values = _context.SocialMedias.ToList();
			return View(values);
		}
	}
}
