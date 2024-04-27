using System.Composition;

namespace MyPortfolioProject.DAL.Entities
{
    public class Image
    {
		// Gorsellerin tutulacagi tablo
		// Entity Constructure
		public Image()
		{

		}
		public Image(string fileName, string fileType)
		{
			FileName = fileName;
			FileType = fileType;
		}
		public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; }
        public ICollection<Feature> Features { get; set; } // Once cikan alan icin fotograf yukleme islemi
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
