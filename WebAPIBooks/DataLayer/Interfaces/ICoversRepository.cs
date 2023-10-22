using WebAPIBooks.DTOs;
using WebAPIBooks.Entities;

namespace WebAPIBooks.DataLayer.Interfaces
{
    public interface ICoversRepository
    {
        Task AddCoverAsync(Cover cover);
        Task DeleteCoverAsync(Guid id);
        Task<Cover> GetCoverByIdAsync(Guid id);
        Task UpdateCoverAsync(Cover cover);
    }
}
