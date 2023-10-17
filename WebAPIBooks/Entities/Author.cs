using System.ComponentModel.DataAnnotations;

namespace WebAPIBooks.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
