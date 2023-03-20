using System.ComponentModel.DataAnnotations;

namespace Books.Infrastructure.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;
    }
}
