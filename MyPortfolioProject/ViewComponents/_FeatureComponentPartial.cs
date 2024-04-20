using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;
using System.IdentityModel.Tokens.Jwt;

namespace MyPortfolioProject.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        AppDbContext _context=new AppDbContext();


        public IViewComponentResult Invoke()
        {
            var values = _context.Features.ToList();
            return View(values);
        }
    }
}
