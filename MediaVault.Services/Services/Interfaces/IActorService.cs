using MediaVault.Models.DTOs.Actors;

namespace MediaVault.Services.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorDto>> GetAllAsync();
        Task<ActorDto?> GetByIdAsync(int id);
        Task<ActorDto> CreateAsync(CreateActorDto dto);
        Task<bool> UpdateAsync(int id, UpdateActorDto dto);
        Task<bool> SoftDeleteAsync(int id);
    }
}
