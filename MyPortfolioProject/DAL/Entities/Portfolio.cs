namespace MyPortfolioProject.DAL.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public Guid? ImageId { get; set; } // Gorsel yukleme islemi bos da gecilebilir
        public Image Image { get; set; }
    }
}
