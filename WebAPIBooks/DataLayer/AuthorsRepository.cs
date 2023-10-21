using Microsoft.EntityFrameworkCore;
using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BooksDbContext _context;   

        public AuthorsRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Authors.OrderBy(a => a.Name).ToListAsync();

            return authors; 
        }
           
    }
}
