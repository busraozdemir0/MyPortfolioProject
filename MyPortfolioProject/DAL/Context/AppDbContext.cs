using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.DAL.Context
{
    public class AppDbContext:DbContext
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
    }
}
