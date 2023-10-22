using Microsoft.AspNetCore.Mvc;
using WebAPIBooks.DTOs;
using WebAPIBooks.Services.Interfaces;

namespace WebAPIBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : ControllerBase
    {
        private readonly ICoversService _coversService;

        public CoversController(ICoversService coversService)
        {
            _coversService = coversService;
        }

        [HttpGet]
        public async Task<ActionResult<BookDto>> Get(Guid id)
        {
            var cover = await _coversService.GetCoverByIdAsync(id);

            return Ok(cover);
        }
    }
}
