using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public interface IAuthorsRepository
    {
        Task AddAuthorAsync(Author author);
        Task<IEnumerable<Author>> GetAuthorsAsync();
    }
}
