namespace MVC.Models
{
    public class BookModel
    {
        // Properties
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int Year { get; set; }
        public int rating { get; set; }
        public bool haveRead { get; set; }
    }
}