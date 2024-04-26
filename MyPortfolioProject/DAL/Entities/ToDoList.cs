namespace MyPortfolioProject.DAL.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; } // Icon bilgisi (la la-comment gibi)
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
