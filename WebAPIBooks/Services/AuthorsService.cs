using WebAPIBooks.DataLayer;
using WebAPIBooks.DTOs;
using WebAPIBooks.Entities;

namespace WebAPIBooks.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorRepository;

        public AuthorsService(IAuthorsRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task AddAuthorAsync(AuthorDto author)
            => await _authorRepository.AddAuthorAsync(new Author { Id = Guid.NewGuid(), Name = author.Name });

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAuthorsAsync();

            return authors.Select(a => new AuthorDto { Id = a.Id, Name = a.Name });
        }
           
    }
}
