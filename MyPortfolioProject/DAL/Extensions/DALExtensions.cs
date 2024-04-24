using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.Helpers.Images;

namespace MyPortfolioProject.DAL.Extensions
{
	public static class DALExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped<IImageHelper, ImageHelper>(); // Gorselleri Image tablosunda tutacagimiz icin Helper yazdik.

			return services;
		}
	}
}
