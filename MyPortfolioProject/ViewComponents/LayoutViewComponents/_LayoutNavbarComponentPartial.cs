using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Extensions;
using System.Security.Claims;

namespace MyPortfolioProject.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial:ViewComponent
	{
		private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public _LayoutNavbarComponentPartial(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public IViewComponentResult Invoke()
		{
            var userId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si
            var user = _context.Users.Include(i => i.Image).Where(x => x.Id == userId).FirstOrDefault();
            ViewBag.UserName = user.Name + " " + user.Surname;
            ViewBag.UserMail = _user.GetLoggedInEmail();
            ViewBag.userImageId = user.ImageId;

            if (user.ImageId is not null)
                ViewBag.UserImage = user.Image.FileName;

            ViewBag.toDoListCount = _context.ToDoLists.Where(x => x.Status == false).Count();
            var values = _context.ToDoLists.Where(x => x.Status == false).ToList(); // Yapilmamis/tamamlanmamis olan toDoList'leri listeleyecek.
			return View(values);
		}
	}
}
