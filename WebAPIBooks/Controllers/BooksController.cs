using Microsoft.AspNetCore.Mvc;
using WebAPIBooks.DTOs;
using WebAPIBooks.Helpers;
using WebAPIBooks.Services;

namespace WebAPIBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPut]
        public async Task<ActionResult> AddBook(BookDto book)
        {
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
            await _booksService.UpdateAsync(book);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _booksService.DeleteAsync(id);

            return NoContent();
        }
    }
}
