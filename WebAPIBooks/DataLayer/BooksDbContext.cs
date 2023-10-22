using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cover> Covers { get; set; }
    }
}
