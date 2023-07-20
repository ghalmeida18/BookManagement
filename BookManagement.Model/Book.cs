using System.ComponentModel.DataAnnotations;

namespace BookManagement.Model
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
