using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents.AdminStatisticComponent
{
    public class _AdminStatisticToDoList : ViewComponent
    {
        private readonly AppDbContext _context;

        public _AdminStatisticToDoList(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var toDoLists = _context.ToDoLists.Where(x => x.Status == false).ToList(); // Yapilmamis gorevler
            return View(toDoLists);
        }
    }
}
