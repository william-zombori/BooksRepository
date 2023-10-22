using WebAPIBooks.DTOs;
using WebAPIBooks.Helpers;

namespace WebAPIBooks.Services
{
    public interface IBooksService
    {
        Task AddBookAsync(BookDto book);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<PaginatedResultsModel<BookDto>> GetBooksAsync(BooksFilterDto filter);
        Task UpdateBookAsync(BookDto user);
        Task DeleteBookAsync(Guid id);
    }
}
