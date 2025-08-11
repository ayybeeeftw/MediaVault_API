using MediaVault.Models.DTOs.Genres;
using MediaVault.Models.DTOs.Shows;

namespace MediaVault.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllAsync();
        Task<GenreDto?> GetByIdAsync(int id);
        Task<GenreDto> CreateAsync(CreateGenreDto dto);
        Task<bool> UpdateAsync(int id, UpdateGenreDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ShowDto>?> GetShowsByGenreIdAsync(int id);
    }
}
