using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;
using MyPortfolioProject.Helpers.Images;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IImageHelper _imageHelper;

        public FeatureController(IImageHelper imageHelper, AppDbContext context)
        {
            _imageHelper = imageHelper;
            _context = context;
        }

        public IActionResult Index()
        {
            // Ana sayfada one cikan alan yazisi icin
            var feature = _context.Features.Include(i => i.Image).FirstOrDefault();
            ViewBag.featureId = feature.Id;
            return View(feature);
        }
        [HttpGet]
        public IActionResult Update(int featureId)
        {
            // Feature tablosu ile Image tablosunu birbirine include ediyoruz (Feature tablosunu listelerken ilgili kayida ait resmi cekebilmek icin)
            var value = _context.Features.Include(i => i.Image).Where(x => x.Id == featureId).FirstOrDefault();
            ViewBag.imageFileName = value.Image.FileName;

            FeatureUpdateViewModel viewModel= new FeatureUpdateViewModel()
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                ImageId = value.ImageId,
            };
            
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(FeatureUpdateViewModel viewModel)
        {
            var feature = _context.Features.Include(i => i.Image).Where(x => x.Id == viewModel.Id).FirstOrDefault();

            if (viewModel.Photo != null) // Eger bir resim secilmisse
            {
                if (viewModel.ImageId != null) // Eger feature guncelleme sirasında ImageId bos degilse yani bir resim varsa o resmi silecegiz.
                    _imageHelper.Delete(feature.Image.FileName); // Once feature'de var olan resmi silecek

                // Ardindan yeni bir image yukleme islemi
                var imageUpload = await _imageHelper.Upload(viewModel.Title, viewModel.Photo);
                Image image = new(imageUpload.FullName, viewModel.Photo.ContentType);
                await _context.Images.AddAsync(image);
                await _context.SaveChangesAsync();

                feature.ImageId = image.Id;
            }

            feature.Title = viewModel.Title;
            feature.Description = viewModel.Description;

            _context.Features.Update(feature);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
