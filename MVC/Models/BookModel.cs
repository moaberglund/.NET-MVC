using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class BookModel
    {
        // Properties

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public required string BookTitle { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Author { get; set; }

        [Required]
        [Range(1, 2025)]
        public required int Year { get; set; }
        public int Rating { get; set; }
        public bool HaveRead { get; set; }
    }
}