using MediaVault.Models.DTOs.Episodes;

namespace MediaVault.Services.Interfaces
{
    public interface IEpisodeService
    {
        Task<IEnumerable<EpisodeDto>> GetAllAsync();
        Task<EpisodeDto?> GetByIdAsync(int id);
        Task<EpisodeDto> CreateAsync(CreateEpisodeDto dto);
        Task<bool> UpdateAsync(int id, UpdateEpisodeDto dto);
        Task<bool> SoftDeleteAsync(int id);
        Task<IEnumerable<EpisodeDto>> GetByShowIdAsync(int showId);
    }
}
