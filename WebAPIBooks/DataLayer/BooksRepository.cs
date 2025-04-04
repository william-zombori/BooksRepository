using Microsoft.EntityFrameworkCore;
using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksDbContext _context;

        public BooksRepository(BooksDbContext context) 
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbBook = (await _context.Books.FindAsync(id)) ?? throw new ArgumentException($"Unable to find a book with Id = '{id}'.");

            _context.Books.Remove(dbBook);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var dbBook = (await _context.Books.FindAsync(id)) ?? throw new ArgumentException($"Unable to find a book with Id = '{id}'.");

            return dbBook;
        }

        public async Task<Tuple<int, IEnumerable<Book>>> GetBooksAsync(string title, string description, IEnumerable<Guid> authorIds, int skipNrOfElems, int takeNrOfElems)
        {
            var query = _context.Books.AsQueryable();

            if(!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(b => b.Description.Contains(description));
            }

            if (authorIds != null && authorIds.Count() > 0)
            {
                query = query.Where(b => authorIds.Contains(b.AuthorId));
            }

            var books = await query.OrderByDescending(b => b.Created).ToListAsync();
            var count = books.Count();
            var booksPage = books.Skip(skipNrOfElems).Take(takeNrOfElems).ToList();

            return new Tuple<int, IEnumerable<Book>>(count, booksPage);
        }

        public async Task UpdateAsync(Book book)
        {
            var dbBook = (await _context.Books.FindAsync(book.Id)) ?? throw new ArgumentException($"Unable to find a book with Id = '{book.Id}'.");
           
            dbBook.Title = book.Title;
            dbBook.Description = book.Description;
            dbBook.AuthorId = book.AuthorId;
            dbBook.CoverId = book.CoverId;
           
            await _context.SaveChangesAsync();
        }
    }
}
