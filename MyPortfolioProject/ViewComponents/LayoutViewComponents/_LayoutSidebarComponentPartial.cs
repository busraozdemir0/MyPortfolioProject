using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Extensions;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace MyPortfolioProject.ViewComponents.LayoutViewComponents
{
	public class _LayoutSidebarComponentPartial:ViewComponent
	{
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public _LayoutSidebarComponentPartial(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public IViewComponentResult Invoke()
		{
            var userId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si
            var user = _context.Users.Include(i => i.Image).Where(x => x.Id == userId).FirstOrDefault();
            ViewBag.NameSurname = user.Name + " " + user.Surname;
            ViewBag.UserName = user.UserName;
            ViewBag.userImageId = user.ImageId;

            if (user.ImageId is not null)
                ViewBag.UserImage = user.Image.FileName;

            return View();
        }
	}
}
