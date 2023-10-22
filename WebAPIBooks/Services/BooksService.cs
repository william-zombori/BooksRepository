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
            => await _bookRepository.AddBookAsync(new Book 
            { 
                Id = Guid.NewGuid(),
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.Author.Id,
                CoverId = book.Cover.Id
            });

        public async Task DeleteBookAsync(Guid id) => await _bookRepository.DeleteAsync(id);    

        public async Task<BookDto> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = new AuthorDto{ Id = book.Author.Id, Name = book.Title },
                Description = book.Description,
                Cover = new CoverDto { Id = book.CoverId }
            };
        }

        public async Task<PaginatedResultsModel<BookDto>> GetBooksAsync(BooksFilterDto filter)
        {
            var result = await _bookRepository.GetBooksAsync(filter.Title, filter.AuthorIds, filter.SkipNrOfElements, filter.TakeNrOfElements);

            return new PaginatedResultsModel<BookDto>(CreateBookDtos(result.Item2), result.Item1);
        }

        public async Task UpdateBookAsync(BookDto book)
           => await _bookRepository.UpdateAsync(new Book
           {
               Id = book.Id,
               AuthorId = book.Author.Id,
               Title = book.Title,
               Description = book.Description,
               CoverId = book.Cover.Id
           });

        private IEnumerable<BookDto> CreateBookDtos(IEnumerable<Book> books)
            => books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = new AuthorDto { Id = b.Author.Id, Name = b.Title },
                Description = b.Description,
                Cover = new CoverDto { Id = b.CoverId }
            });
    }
}
