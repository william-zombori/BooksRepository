using System.ComponentModel.DataAnnotations;

namespace WebAPIBooks.Entities
{
    public class Cover
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public byte[] Image { get; set; } = null!;   //  using the null-forgiving operator (!) to silence the compiler warning.

        public Book? Book { get; set; }
    }
}
