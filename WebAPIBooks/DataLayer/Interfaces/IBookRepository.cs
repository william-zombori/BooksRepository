using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Tuple<int, IEnumerable<Book>>> GetBooksAsync(string title, IEnumerable<string> AuthorNames, int skipNrOfElems, int takeNrOfElems);
        void Update(Book book);
        void Delete(Guid id);
    }
}
