using Microsoft.AspNetCore.Identity;

namespace MyPortfolioProject.DAL.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid? ImageId { get; set; } // Kisinin gorseli Image tablosunda tutulacak.
        public Image Image { get; set; }
    }
}
