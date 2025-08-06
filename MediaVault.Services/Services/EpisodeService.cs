using MediaVault.Models.DTOs.Episodes;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;
using MediaVault.Services.Interfaces;

namespace MediaVault.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _repository;

        public EpisodeService(IEpisodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EpisodeDto>> GetAllAsync()
        {
            var episodes = _repository.GetAll()
                .Where(e => !e.IsDeleted) // ✅ Exclude soft-deleted
                .Select(e => new EpisodeDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Duration = e.Duration,
                    SeasonNumber = e.SeasonNumber,
                    EpisodeNumber = e.EpisodeNumber,
                    Summary = e.Summary,
                    ShowId = e.ShowId
                });

            return await Task.FromResult(episodes);
        }

        public async Task<EpisodeDto?> GetByIdAsync(int id)
        {
            var episode = _repository.GetById(id);
            if (episode == null || episode.IsDeleted) return null;

            var dto = new EpisodeDto
            {
                Id = episode.Id,
                Title = episode.Title,
                Duration = episode.Duration,
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.EpisodeNumber,
                Summary = episode.Summary,
                ShowId = episode.ShowId
            };

            return await Task.FromResult(dto);
        }

        public async Task<EpisodeDto> CreateAsync(CreateEpisodeDto dto)
        {
            var episode = new Episode
            {
                Title = dto.Title,
                Duration = dto.Duration,
                SeasonNumber = dto.SeasonNumber,
                EpisodeNumber = dto.EpisodeNumber,
                Summary = dto.Summary,
                ShowId = dto.ShowId
            };

            _repository.Add(episode);

            var result = new EpisodeDto
            {
                Id = episode.Id,
                Title = episode.Title,
                Duration = episode.Duration,
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.EpisodeNumber,
                Summary = episode.Summary,
                ShowId = episode.ShowId
            };

            return await Task.FromResult(result);
        }
        public async Task<bool> UpdateAsync(int id, UpdateEpisodeDto dto)
        {
            var episode = _repository.GetById(id);
            if (episode == null || episode.IsDeleted) return await Task.FromResult(false);

            episode.Title = dto.Title;
            episode.Duration = dto.Duration;
            episode.SeasonNumber = dto.SeasonNumber;
            episode.EpisodeNumber = dto.EpisodeNumber;
            episode.Summary = dto.Summary;
            episode.ShowId = dto.ShowId;

            _repository.Update(episode);
            return await Task.FromResult(true);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var episode = _repository.GetById(id);
            if (episode == null || episode.IsDeleted) return await Task.FromResult(false);

            episode.IsDeleted = true;
            _repository.Update(episode); // ✅ mark deleted
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<EpisodeDto>> GetByShowIdAsync(int showId)
        {
            var episodes = _repository.GetAll()
                .Where(e => e.ShowId == showId && !e.IsDeleted) // ✅ filter here too
                .Select(e => new EpisodeDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Duration = e.Duration,
                    ShowId = e.ShowId
                });

            return await Task.FromResult(episodes);
        }

    }
}
