using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public interface IBooksRepository
    {
        Task AddBookAsync(Book book);
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Tuple<int, IEnumerable<Book>>> GetBooksAsync(string title, string description, IEnumerable<Guid> authorIds, int skipNrOfElems, int takeNrOfElems);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
    }
}
