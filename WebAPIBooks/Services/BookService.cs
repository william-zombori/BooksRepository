using WebAPIBooks.DataLayer;
using WebAPIBooks.DTOs;
using WebAPIBooks.Entities;
using WebAPIBooks.Helpers;

namespace WebAPIBooks.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(BookDto book)
            => _bookRepository.AddBook(new Book { Id = Guid.NewGuid(),
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId
            });

        public void Delete(Guid id) => _bookRepository.Delete(id);

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
            var result = await _bookRepository.GetBooksAsync(filter.Title, filter.AuthorNames, filter.SkipNrOfElements, filter.TakeNrOfElements);

            return new PaginatedResultsModel<BookDto>(CreateBookDtos(result.Item2), result.Item1);
        }

        public void Update(BookDto book)
           => _bookRepository.Update(new Book
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
