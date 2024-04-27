using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;
using MyPortfolioProject.Helpers.Images;
using MyPortfolioProject.Models;
using System.Composition;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
	{
        private readonly AppDbContext _context;
        private readonly IImageHelper _imageHelper;

        public PortfolioController(IImageHelper imageHelper, AppDbContext context)
        {
            _imageHelper = imageHelper;
            _context = context;
        }

        public IActionResult Index()
		{
			var porfolios = _context.Portfolios.Include(i => i.Image).ToList();
			return View(porfolios);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(PortfolioAddViewModel viewModel)
		{
			if (viewModel.Image != null) // Eger resim secmisse
			{
				// Resim yukleme islemleri
				var imageUpload = await _imageHelper.Upload(viewModel.Title, viewModel.Image);
				Image image = new(imageUpload.FullName, viewModel.Image.ContentType);
				await _context.Images.AddAsync(image);
				await _context.SaveChangesAsync();
				
				// Entity Constructure sayesinde resmiyle beraber Portfolio olusturduk.
				Portfolio portfolio = new Portfolio
				{
					Title = viewModel.Title,
					SubTitle = viewModel.SubTitle,
					Description = viewModel.Description,
					Url = viewModel.Url,
					ImageId = image.Id
				};

				await _context.Portfolios.AddAsync(portfolio);
				await _context.SaveChangesAsync();

			}
			else // Resim secmemisse
			{
				var portfolio = new Portfolio() // Resim haricindeki alanlari Portfolio nesnesine aktar
                {
					Title = viewModel.Title,
					SubTitle = viewModel.SubTitle,
					Description = viewModel.Description,
					Url = viewModel.Url,
				};
				_context.Portfolios.Add(portfolio);
				_context.SaveChanges();

			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(int portfolioId)
		{
			var value = _context.Portfolios.Include(i => i.Image).Where(x => x.Id == portfolioId).FirstOrDefault();
			ViewBag.imageFileName = value.Image.FileName;

			PortfolioUpdateViewModel viewModel = new PortfolioUpdateViewModel()
			{
				Id = value.Id,
				Title = value.Title,
				SubTitle = value.SubTitle,
				Description = value.Description,
				Url = value.Url,
				ImageId = value.ImageId,
			};
			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Update(PortfolioUpdateViewModel viewModel)
		{
			var portfolio = _context.Portfolios.Include(i => i.Image).Where(x => x.Id == viewModel.Id).FirstOrDefault();

			if (viewModel.Photo != null) // Eger bir resim secilmisse
			{
				if (viewModel.ImageId != null) // Eger portfolyo guncelleme sirasinda ImageId bos degilse yani bir resim varsa o resmi silecegiz.
                    _imageHelper.Delete(portfolio.Image.FileName); // Once portfolyo'da var olan resmi silecek

				// Ardindan yeni bir image yukleme islemi
				var imageUpload = await _imageHelper.Upload(viewModel.Title, viewModel.Photo);
				Image image = new(imageUpload.FullName, viewModel.Photo.ContentType);
				await _context.Images.AddAsync(image);
				await _context.SaveChangesAsync();

				portfolio.ImageId = image.Id;
			}

			portfolio.Title = viewModel.Title;
			portfolio.SubTitle=viewModel.SubTitle;
			portfolio.Description=viewModel.Description;
			portfolio.Url = viewModel.Url;

			 _context.Portfolios.Update(portfolio);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		public IActionResult Delete(int portfolioId)
		{
			var value = _context.Portfolios.Find(portfolioId);
			_context.Portfolios.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
