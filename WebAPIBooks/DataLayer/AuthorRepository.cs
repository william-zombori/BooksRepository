using Microsoft.EntityFrameworkCore;
using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooksDbContext _context;   

        public AuthorRepository(BooksDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Authors.OrderBy(a => a.Name).ToListAsync();

            return authors; 
        }
           
    }
}
