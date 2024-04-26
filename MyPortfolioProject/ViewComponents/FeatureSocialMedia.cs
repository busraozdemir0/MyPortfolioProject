using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
	public class FeatureSocialMedia:ViewComponent
	{
        private readonly AppDbContext _context;

        public FeatureSocialMedia(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
		{
			var values = _context.SocialMedias.ToList();
			return View(values);
		}
	}
}
