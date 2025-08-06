using MediaVault.Models.DTOs.Genres;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;
using MediaVault.Services.Interfaces;

namespace MediaVault.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres = _repository.GetAll()
                .Where(g => !g.IsDeleted) // ✅ exclude soft-deleted
                .Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description
                });

            return await Task.FromResult(genres);
        }

        public async Task<GenreDto?> GetByIdAsync(int id)
        {
            var genre = _repository.GetById(id);
            if (genre == null || genre.IsDeleted) return null;

            var dto = new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };

            return await Task.FromResult(dto);
        }

        public async Task<GenreDto> CreateAsync(CreateGenreDto dto)
        {
            var genre = new Genre
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _repository.Add(genre);

            var result = new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };

            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateAsync(int id, UpdateGenreDto dto)
        {
            var genre = _repository.GetById(id);
            if (genre == null || genre.IsDeleted) return await Task.FromResult(false);

            genre.Name = dto.Name;
            genre.Description = dto.Description;

            _repository.Update(genre);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var genre = _repository.GetById(id);
            if (genre == null || genre.IsDeleted) return await Task.FromResult(false);

            genre.IsDeleted = true;
            _repository.Update(genre);
            return await Task.FromResult(true);
        }
    }
}
