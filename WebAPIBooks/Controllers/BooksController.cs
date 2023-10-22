using Microsoft.AspNetCore.Mvc;
using WebAPIBooks.DTOs;
using WebAPIBooks.Helpers;
using WebAPIBooks.Services;
using WebAPIBooks.Services.Interfaces;

namespace WebAPIBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ICoversService _coversService;

        public BooksController(IBooksService booksService, ICoversService coversService)
        {
            _booksService = booksService;
            _coversService = coversService;
        }

        [HttpPut]
        public async Task<ActionResult> AddBook(BookDto book)
        {
            var coverId = await _coversService.AddCoverAsync(book.Cover);
            book.Cover.Id = coverId;

            await _booksService.AddBookAsync(book);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(Guid id)
        {
            var book = await _booksService.GetBookByIdAsync(id);

            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResultsModel<BookDto>>> GetBooks(BooksFilterDto filter)
        {
            var books = await _booksService.GetBooksAsync(filter);

            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> Update(BookDto book)
        {
            if(book.IsCoverImageChanged)
            {
                await  _coversService.UpdateCoverAsync(book.Cover);
            }

            await _booksService.UpdateBookAsync(book);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(BookDto book)
        {
            await _coversService.DeleteCoverAsync(book.Cover.Id);
            await _booksService.DeleteBookAsync(book.Id);

            return NoContent();
        }
    }
}
