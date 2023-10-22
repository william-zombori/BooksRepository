using System.ComponentModel.DataAnnotations;

namespace WebAPIBooks.Entities
{
    public class Cover
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public byte[] Image { get; set; } = null!;

        public Book? Book { get; set; }
    }
}
