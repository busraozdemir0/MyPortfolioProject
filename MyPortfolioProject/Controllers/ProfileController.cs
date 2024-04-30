using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;
using MyPortfolioProject.DAL.Extensions;
using MyPortfolioProject.Helpers.Images;
using MyPortfolioProject.Models;
using System.Security.Claims;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IImageHelper _imageHelper;

        public ProfileController(IHttpContextAccessor httpContextAccessor, AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IImageHelper imageHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _user = httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public IActionResult Update()
        {
            var userId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si
            var user = _context.Users.Include(i => i.Image).Where(x => x.Id == userId).FirstOrDefault(); // Giren kisinin id'sine ait bilgileri image'i include ederek getir.
            UserProfileViewModel viewModel = new()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                ImageId = user.ImageId,
            };
            if(user.ImageId is not null)
                ViewBag.UserImage = user.Image.FileName;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserProfileViewModel viewModel)
        {
            var userId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si
            var user = await _userManager.FindByIdAsync(userId.ToString());

            Guid? imageId = user.ImageId; // Giris yapan kullanicinin image id'si

            var isVerified = await _userManager.CheckPasswordAsync(user, viewModel.CurrentPassword); // Mevcuttaki sifre dogruysa true donecek.
            if (isVerified && viewModel.NewPassword != null) // Eger yeni sifre alanina deger girilmisse sifre degistirme islemi yapilacak.
            {
                var result = await _userManager.ChangePasswordAsync(user, viewModel.CurrentPassword, viewModel.NewPassword); // Sifre degisme islemi
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync(); // Sifre degistirildigi icin cikis yaptirdik.
                    await _signInManager.PasswordSignInAsync(user, viewModel.NewPassword, true, false); // Ardindan yeni sifreyle otomatikman tekrar giris yaptiriyoruz.

                    user.Name=viewModel.Name;
                    user.Surname=viewModel.Surname;
                    user.Email=viewModel.Email;
                    user.UserName=viewModel.UserName;
                    user.PhoneNumber=viewModel.PhoneNumber;                   

                    user.ImageId = imageId;

                    if (viewModel.Photo != null) // Eger kullanici resim sectiyse resim yukleme isleminin ardindan ImageId bilgisi guncelleniyor.
                    {
                        // Resim yukleme islemleri
                        var imageUpload = await _imageHelper.Upload(viewModel.Name, viewModel.Photo);
                        Image image = new(imageUpload.FullName, viewModel.Photo.ContentType);
                        await _context.Images.AddAsync(image);

                        user.ImageId = image.Id;
                    }

                    await _userManager.UpdateAsync(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Statistic");
                }

                else
                    return View();
            }
            else if (isVerified)
            {
                await _userManager.UpdateSecurityStampAsync(user);

                user.Name = viewModel.Name;
                user.Surname = viewModel.Surname;
                user.Email = viewModel.Email;
                user.UserName = viewModel.UserName;
                user.PhoneNumber = viewModel.PhoneNumber;

                user.ImageId = imageId;

                if (viewModel.Photo != null) // Eger kullanici resim sectiyse resim yukleme isleminin ardindan ImageId bilgisi guncelleniyor.
                {
                    // Resim yukleme islemleri
                    var imageUpload = await _imageHelper.Upload(viewModel.Name, viewModel.Photo);
                    Image image = new(imageUpload.FullName, viewModel.Photo.ContentType);
                    await _context.Images.AddAsync(image);

                    user.ImageId = image.Id;
                }

                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Statistic");
            }

            else
                return View();

        }
    }
}
