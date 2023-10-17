using WebAPIBooks.DTOs;
using WebAPIBooks.Helpers;

namespace WebAPIBooks.Services
{
    public interface IBookService
    {
        void AddBook(BookDto book);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<PaginatedResultsModel<BookDto>> GetBooksAsync(BooksFilterDto filter);
        void Update(BookDto user);
        void Delete(Guid id);
    }
}
