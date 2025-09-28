using System.ComponentModel.DataAnnotations;

namespace WebAPIBooks.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(450)]
        public string Title { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = true), MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
       
        public DateTime Created { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; } = null!;   //  using the null-forgiving operator (!) to silence the compiler warning.

        public Guid CoverId { get; set; }

        public Cover Cover { get; set; } = null!;   //  using the null-forgiving operator (!) to silence the compiler warning. 
    }
}
