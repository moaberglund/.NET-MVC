namespace MVC.Models
{
    public class BookModel
    {
        // Properties
        public required string BookTitle { get; set; }
        public required string Author { get; set; }
        public required int Year { get; set; }
        public int Rating { get; set; }
        public bool HaveRead { get; set; }
    }
}