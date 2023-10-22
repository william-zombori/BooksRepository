using WebAPIBooks.DataLayer.Interfaces;
using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer
{
    public class CoversRepository : ICoversRepository
    {
        private readonly BooksDbContext _context;

        public CoversRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task AddCoverAsync(Cover cover)
        {
            await _context.Covers.AddAsync(cover);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoverAsync(Guid id)
        {
            var dbCover = (await _context.Covers.FindAsync(id)) ?? throw new ArgumentException($"Unable to find a cover with Id = '{id}'.");

            _context.Covers.Remove(dbCover);
            await _context.SaveChangesAsync();
        }

        public async Task<Cover> GetCoverByIdAsync(Guid id)
        {
            var dbCover = (await _context.Covers.FindAsync(id)) ?? throw new ArgumentException($"Unable to find a cover with Id = '{id}'.");
        
            return dbCover;
        }

        public async Task UpdateCoverAsync(Cover cover)
        {
            var dbCover = (await _context.Covers.FindAsync(cover.Id)) ?? throw new ArgumentException($"Unable to find a cover with Id = '{cover.Id}'.");

            dbCover.Image = cover.Image;

            await _context.SaveChangesAsync();
        }
    }
}
