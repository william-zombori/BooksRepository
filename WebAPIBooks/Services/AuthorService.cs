using WebAPIBooks.DataLayer;
using WebAPIBooks.DTOs;
using WebAPIBooks.Entities;

namespace WebAPIBooks.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthor(AuthorDto author)
            => _authorRepository.AddAuthor(new Author {Id = Guid.NewGuid(), Name = author.Name });

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAuthorsAsync();

            return authors.Select(a => new AuthorDto { Id = a.Id, Name = a.Name });
        }
           
    }
}
