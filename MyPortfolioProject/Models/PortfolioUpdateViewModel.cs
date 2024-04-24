using MyPortfolioProject.DAL.Entities;

namespace MyPortfolioProject.Models
{
	public class PortfolioUpdateViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public Guid? ImageId { get; set; }
		public Image Image { get; set; }
		public IFormFile? Photo { get; set; }
	}
}
