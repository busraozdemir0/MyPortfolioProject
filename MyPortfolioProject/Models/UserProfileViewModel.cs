using MyPortfolioProject.DAL.Entities;
using System.Diagnostics;

namespace MyPortfolioProject.Models
{
    public class UserProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; } // Nullable yapmamizin sebebi => kisi eger parolasini degistermek istemedigi durum icin 
        public IFormFile? Photo { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
