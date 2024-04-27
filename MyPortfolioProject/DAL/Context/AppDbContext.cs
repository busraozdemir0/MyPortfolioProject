using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Baglanti stringi daha guvenli olmasi acisindan appsettings.json dosyasina yazilmalidir.

            optionsBuilder.UseSqlServer("Server=DESKTOP-43HIK1B; initial Catalog=MyPortfolioDb; integrated Security=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Image> Images { get; set; }

        // * kayitli kullaniciya admin rolu atayabilmek icin-
        // !!! VERITABANI OLUSTURULDUKTAN SONRA ASPNETUSERROLES TABLOSUNA => ASPNETUSERS TABLOSUNDAN USERID BILGISINI VE
        // ASPNETROLES TABLOSUNDAN ROLEID'YI ILGILI ALANLARA KOPYALA 


        // Sifrelerin hash'lenerek tutulabilmesi icin bu yapi olusturuluyor
        public string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User seed data
            var admin = new AppUser
            {
                Id = Guid.Parse("E6E21232-145C-44A1-ADE1-9DB6646F39C3"),
                Name = "Büşra",
                Surname = "Özdemir",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "busraozdm1@gmail.com",
                NormalizedEmail = "BUSRAOZDM1@GMAIL.COM",
                PhoneNumber = "(111) 111 1111",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");

            modelBuilder.Entity<AppUser>().HasData(admin);

            // Role seed data
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = Guid.Parse("9F4A2DBA-20CA-481C-AF32-70DF2C57B256"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

            // About seed data
            modelBuilder.Entity<About>().HasData(
                new About
                {
                    Id = 1,
                    Title = "Ben Kimim",
                    SubDescription = "Hakkımda Daha Fazlası",
                    Details = "Düzce Üniversitesi Bilgisayar Mühendisliği son sınıf öğrencisiyim. Araştırmayı, yeni bilgiler öğrenmeyi " +
                            "ve her geçen gün kendimi geliştirmeyi seviyorum. Azimli, hırslı, ve sorumluluk sahibi biri olmanın yanı sıra takım çalışmasına da yatkınım. " +
                            "Şu an aktif olarak ASP.NET Core MVC, SignalR, Mediatr, Web Api, " +
                            "gibi web alanlarında yazılım geliştiriyor, aynı zamanda yeni şeyler " +
                            "öğreniyorum. "
                });

            // Feature seed data
            modelBuilder.Entity<Feature>().HasData(
                new Feature
                {
                    Id = 1,
                    Title = "Merhaba",
                    Description = "Ben Büşra. Düzce Üniversitesi Bilgisayar Mühendisliği son sınıf öğrencisiyim."
                });

            // Contact seed data
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Title = "Bana Ulaşın",
                    Description = "Merak ettiğiniz her konu hakkında bana mesaj atabilirsiniz. En kısa sürede dönüş yapacağım.",
                    Phone = "(123) 456 7788",
                    Email = "81busraozdemir@gmail.com",
                    Address = "Düzce, Türkiye"
                });




        }
    }
}
