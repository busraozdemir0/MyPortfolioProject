using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;
using MyPortfolioProject.Helpers.Images;

namespace MyPortfolioProject.DAL.Extensions
{
	public static class DALExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
		{
            services.AddDbContext<AppDbContext>();

			// identity'nin servis kaydi
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>()
				.AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<AppDbContext>();

			services.AddScoped<IImageHelper, ImageHelper>(); // Gorselleri Image tablosunda tutacagimiz icin Helper yazdik.
			

			return services;
		}
	}
}
