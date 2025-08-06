using MediaVault.Models.DTOs.Shows;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;
using MediaVault.Services.Interfaces;

public class ShowService : IShowService
{
    private readonly IShowRepository _repository;

    public ShowService(IShowRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ShowDto>> GetAllAsync()
    {
        var shows = _repository.GetAll()
            .Where(s => !s.IsDeleted)
            .Select(s => new ShowDto
            {
                Id = s.Id,
                Title = s.Title,
                GenreId = s.GenreId,
                GenreName = s.Genre.Name,
                Seasons = s.Seasons,
                Type = s.Type,
                IsCompleted = s.IsCompleted,
                Language = s.Language,
                Country = s.Country,
                Summary = s.Summary,
                ReleaseDate = s.ReleaseDate,
                Rating = s.Rating
            });

        return await Task.FromResult(shows);
    }

    public async Task<ShowDto?> GetByIdAsync(int id)
    {
        var show = _repository.GetById(id);
        if (show == null || show.IsDeleted) return null;

        var result = new ShowDto
        {
            Id = show.Id,
            Title = show.Title,
            GenreId = show.GenreId,
            GenreName = show.Genre.Name,
            Seasons = show.Seasons,
            Type = show.Type,
            IsCompleted = show.IsCompleted,
            Language = show.Language,
            Country = show.Country,
            Summary = show.Summary,
            ReleaseDate = show.ReleaseDate,
            Rating = show.Rating
        };

        return await Task.FromResult(result);
    }

    public async Task<ShowDto> CreateAsync(CreateShowDto dto)
    {
        var show = new Show
        {
            Title = dto.Title,
            GenreId = dto.GenreId,
            Seasons = dto.Seasons,
            Type = dto.Type,
            IsCompleted = dto.IsCompleted,
            Language = dto.Language,
            Country = dto.Country,
            Summary = dto.Summary,
            ReleaseDate = dto.ReleaseDate,
            Rating = dto.Rating
        };

        _repository.Add(show);

        var result = new ShowDto
        {
            Id = show.Id,
            Title = show.Title,
            GenreId = show.GenreId,
            GenreName = show.Genre?.Name ?? "",
            Seasons = show.Seasons,
            Type = show.Type,
            IsCompleted = show.IsCompleted,
            Language = show.Language,
            Country = show.Country,
            Summary = show.Summary,
            ReleaseDate = show.ReleaseDate,
            Rating = show.Rating
        };

        return await Task.FromResult(result);
    }

    public async Task<bool> UpdateAsync(int id, UpdateShowDto dto)
    {
        var show = _repository.GetById(id);
        if (show == null || show.IsDeleted) return await Task.FromResult(false);

        show.Title = dto.Title;
        show.GenreId = dto.GenreId;
        show.Seasons = dto.Seasons;
        show.Type = dto.Type;
        show.IsCompleted = dto.IsCompleted;
        show.Language = dto.Language;
        show.Country = dto.Country;
        show.Summary = dto.Summary;
        show.ReleaseDate = dto.ReleaseDate;
        show.Rating = dto.Rating;

        _repository.Update(show);
        return await Task.FromResult(true);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var show = _repository.GetById(id);
        if (show == null || show.IsDeleted) return await Task.FromResult(false);

        show.IsDeleted = true;
        _repository.Update(show);
        return await Task.FromResult(true);
    }
}
