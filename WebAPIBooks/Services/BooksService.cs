using WebAPIBooks.DataLayer;
using WebAPIBooks.DTOs;
using WebAPIBooks.Entities;
using WebAPIBooks.Helpers;

namespace WebAPIBooks.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;

        public BooksService(IBooksRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBookAsync(BookDto book)
            => await _bookRepository.AddBookAsync(new Book { Id = Guid.NewGuid(),
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId
            });

        public async Task DeleteAsync(Guid id) => await _bookRepository.DeleteAsync(id);    

        public async Task<BookDto> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.Name,
                AuthorId = book.Author.Id,
                Description = book.Description,
                Image = book.Image
            };
        }

        public async Task<PaginatedResultsModel<BookDto>> GetBooksAsync(BooksFilterDto filter)
        {
            var result = await _bookRepository.GetBooksAsync(filter.Title, filter.AuthorIds, filter.SkipNrOfElements, filter.TakeNrOfElements);

            return new PaginatedResultsModel<BookDto>(CreateBookDtos(result.Item2), result.Item1);
        }

        public async Task UpdateAsync(BookDto book)
           => await _bookRepository.UpdateAsync(new Book
           {
               AuthorId = book.AuthorId,
               Title = book.Title,
               Description = book.Description,
               Image = book.Image 
           });

        private IEnumerable<BookDto> CreateBookDtos(IEnumerable<Book> books)
            => books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                AuthorName = b.Author.Name,
                Description = b.Description,
                Image = b.Image
            });
    }
}
