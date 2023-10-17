using WebAPIBooks.DTOs;

namespace WebAPIBooks.Services
{
    public interface IAuthorService
    {
        void AddAuthor(AuthorDto author);
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    }
}
