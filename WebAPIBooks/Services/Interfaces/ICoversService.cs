using WebAPIBooks.DTOs;

namespace WebAPIBooks.Services.Interfaces
{
    public interface ICoversService
    {
        Task<Guid> AddCoverAsync(CoverDto cover);
        Task DeleteCoverAsync(Guid id);
        Task<CoverDto> GetCoverByIdAsync(Guid id);
        Task UpdateCoverAsync(CoverDto cover);
    }
}
