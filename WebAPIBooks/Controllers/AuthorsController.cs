using Microsoft.AspNetCore.Mvc;
using WebAPIBooks.DTOs;
using WebAPIBooks.Services;

namespace WebAPIBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
       
        public AuthorsController(IAuthorsService authorsService) 
        {
            _authorsService = authorsService;
        }

        [HttpPut]
        public async Task<ActionResult> AddAuthor(AuthorDto author)
        {
            await _authorsService.AddAuthorAsync(author);

            return NoContent();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var authors = await _authorsService.GetAuthorsAsync();

            return Ok(authors); 
        }
    }
}