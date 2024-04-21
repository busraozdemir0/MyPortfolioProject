using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.LayoutViewComponents
{
	public class _LayoutScriptComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
