using System.ComponentModel.DataAnnotations;

namespace WebAPIBooks.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(450)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(2500)]
        public string Description { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
