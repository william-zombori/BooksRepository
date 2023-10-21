using WebAPIBooks.DTOs;

namespace WebAPIBooks.Services
{
    public interface IAuthorsService
    {
        Task AddAuthorAsync(AuthorDto author);
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    }
}
