using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        Task<IEnumerable<Author>> GetAuthorsAsync();
    }
}
