using System.ComponentModel.DataAnnotations;

namespace Books.Infrastructure.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}
