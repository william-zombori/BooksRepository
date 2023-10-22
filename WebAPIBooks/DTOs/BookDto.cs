namespace WebAPIBooks.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorDto Author { get; set; }
        public CoverDto Cover { get; set; }
        public bool IsCoverImageChanged { get; set; } = false;
    }
}
