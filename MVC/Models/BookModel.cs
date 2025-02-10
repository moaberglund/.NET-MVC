using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class BookModel
    {
        // Properties

        [Required(ErrorMessage = "Please enter a book title.")]
        [MinLength(1)]
        [MaxLength(50)]
        public required string BookTitle { get; set; }

        [Required(ErrorMessage = "Plese enter the name of the author.")]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Author { get; set; }

        [Required(ErrorMessage = "Please enter which year the book was published.")]
        [Range(1, 2025)]
        public required int Year { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }
        public bool HaveRead { get; set; }
    }
}