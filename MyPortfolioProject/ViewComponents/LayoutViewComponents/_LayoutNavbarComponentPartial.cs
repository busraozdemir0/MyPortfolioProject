using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial:ViewComponent
	{
		AppDbContext _context = new AppDbContext();
		public IViewComponentResult Invoke()
		{
            ViewBag.toDoListCount = _context.ToDoLists.Where(x => x.Status == false).Count();
            var values = _context.ToDoLists.Where(x => x.Status == false).ToList(); // Yapilmamis/tamamlanmamis olan toDoList'leri listeleyecek.
			return View(values);
		}
	}
}
