using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using System.IdentityModel.Tokens.Jwt;

namespace MyPortfolioProject.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _FeatureComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Features.Include(i => i.Image).FirstOrDefault(); // One cikan alan icin sadece bir tane kayit olmasi gerektigi icin ilk kaydi view tarafina gonderiyoruz.
            ViewBag.imageFileName = value.Image.FileName;
            return View(value);
        }
    }
}
