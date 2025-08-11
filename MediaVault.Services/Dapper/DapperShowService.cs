using Dapper;
using MediaVault.Models.Models.DTOs.Dapper;
using MediaVault.Models.Models.DTOs.Shows;
using System.Data;

namespace MediaVault.Services.Dapper
{
    public class DapperShowService
    {
        private readonly IDbConnection _db;

        public DapperShowService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ShowSearchDto>> SearchShowsAsync(string? title, int? genreId, bool? isCompleted)
        {
            var sql = @"
            SELECT s.Id, s.Title, s.Type, s.IsCompleted, g.Name AS GenreName
            FROM Shows s
            INNER JOIN Genres g ON s.GenreId = g.Id
            /**where**/";


            var builder = new SqlBuilder();
            var parameters = new DynamicParameters();

            // Always include this:
            builder.Where("s.IsDeleted = 0");

            // Optional filters
            if (!string.IsNullOrWhiteSpace(title))
            {
                builder.Where("s.Title LIKE @Title");
                parameters.Add("Title", $"%{title}%");
            }

            if (genreId.HasValue)
            {
                builder.Where("s.GenreId = @GenreId");
                parameters.Add("GenreId", genreId.Value);
            }

            if (isCompleted.HasValue)
            {
                builder.Where("s.IsCompleted = @IsCompleted");
                parameters.Add("IsCompleted", isCompleted.Value);
            }

            var template = builder.AddTemplate(sql);
            return await _db.QueryAsync<ShowSearchDto>(template.RawSql, parameters);
        }

        public async Task<IEnumerable<ShowWithEpisodeCountDto>> GetShowsWithEpisodeCountsAsync()
        {
            var sql = @"
        SELECT s.Title, COUNT(e.Id) AS EpisodeCount, s.Rating
        FROM Shows s
        LEFT JOIN Episodes e ON s.Id = e.ShowId
        WHERE s.IsDeleted = 0 AND s.Rating > 8.6
        GROUP BY s.Title, s.Rating
        ORDER BY s.Rating DESC;
    ";

            return await _db.QueryAsync<ShowWithEpisodeCountDto>(sql);
        }

    }
}
