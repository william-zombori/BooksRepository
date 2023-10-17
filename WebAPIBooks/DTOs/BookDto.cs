namespace WebAPIBooks.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public byte[] Image { get; set; }
    }
}
