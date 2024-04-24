namespace MyPortfolioProject.DAL.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; } // Referansin meslegi ya da unvani
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
