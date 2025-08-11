using Dapper;
using MediaVault.Repositories.Data;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;
using MediaVault.Models.DTOs.Shows;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace MediaVault.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList(); // manual filtering in service layer
        }

        public Genre? GetById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public void Add(Genre genre)
        {
            genre.IsDeleted = false;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var genre = GetById(id);
            if (genre != null)
            {
                genre.IsDeleted = true;
                _context.Genres.Update(genre);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Genres.Any(g => g.Id == id);
        }

        public async Task<IEnumerable<ShowDto>> GetShowsByGenreIdAsync(int genreId)
        {
            var sql = @"SELECT s.Id, s.Title, s.GenreId, g.Name AS GenreName, s.Seasons, s.Type,
                               s.IsCompleted, s.Language, s.Country, s.Summary, s.ReleaseDate, s.Rating
                        FROM Shows s
                        INNER JOIN Genres g ON s.GenreId = g.Id
                        WHERE s.GenreId = @GenreId AND s.IsDeleted = 0 AND g.IsDeleted = 0
                        ORDER BY s.Rating DESC";

            using var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            var shows = await connection.QueryAsync<ShowDto>(sql, new { GenreId = genreId });
            return shows ?? Array.Empty<ShowDto>();
        }
    }
}
