using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Models
{
    public class FeatureUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ImageId { get; set; } // Gorsel yukleme islemi bos da gecilebilir
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
