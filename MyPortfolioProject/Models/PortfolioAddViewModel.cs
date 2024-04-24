namespace MyPortfolioProject.Models
{
	public class PortfolioAddViewModel
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public IFormFile? Image { get; set; }
	}
}
