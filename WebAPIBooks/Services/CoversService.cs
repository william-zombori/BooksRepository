using WebAPIBooks.DataLayer.Interfaces;
using WebAPIBooks.DTOs;
using WebAPIBooks.Entities;
using WebAPIBooks.Services.Interfaces;

namespace WebAPIBooks.Services
{
    public class CoversService : ICoversService
    {
        private readonly ICoversRepository _coversRepository;

        public CoversService(ICoversRepository coversRepository)
        {
            _coversRepository = coversRepository;
        }

        public async Task<Guid> AddCoverAsync(CoverDto cover)
        {
            var id = Guid.NewGuid();
            await _coversRepository.AddCoverAsync(new Cover { Id = id, Image = cover.Image });

            return id;
        }

        public async Task DeleteCoverAsync(Guid id) => await _coversRepository.DeleteCoverAsync(id);

        public async Task<CoverDto> GetCoverByIdAsync(Guid id)
        {
            var cover = await _coversRepository.GetCoverByIdAsync(id);

            return new CoverDto { Id = cover.Id, Image = cover.Image };
        }

        public async Task UpdateCoverAsync(CoverDto cover) => await _coversRepository.UpdateCoverAsync(new Cover { Id = cover.Id, Image = cover.Image });
    }
}
