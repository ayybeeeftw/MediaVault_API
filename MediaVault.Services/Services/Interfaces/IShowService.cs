using MediaVault.Models.DTOs.Shows;

namespace MediaVault.Services.Interfaces
{
    public interface IShowService
    {
        Task<IEnumerable<ShowDto>> GetAllAsync();
        Task<ShowDto?> GetByIdAsync(int id);
        Task<ShowDto> CreateAsync(CreateShowDto dto);
        Task<bool> UpdateAsync(int id, UpdateShowDto dto);
        Task<bool> SoftDeleteAsync(int id);
    }
}
