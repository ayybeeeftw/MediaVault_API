using System.Data;
using Dapper;
using MediaVault.Models.Models.DTOs.Dapper;

namespace MediaVault.Services.Dapper
{
    public class DapperDashboardService
    {
        private readonly IDbConnection _db;

        public DapperDashboardService(IDbConnection db)
        {
            _db = db;
        }

        public async Task<DashboardSummaryDto> GetDashboardSummaryAsync()
        {
            var sql = @"
                SELECT 
                    (SELECT COUNT(*) FROM Shows WHERE IsDeleted = 0) AS TotalShows,
                    (SELECT COUNT(*) FROM Episodes WHERE IsDeleted = 0) AS TotalEpisodes,
                    (SELECT COUNT(*) FROM Actors WHERE IsDeleted = 0) AS TotalActors,
                    (SELECT COUNT(*) FROM Genres WHERE IsDeleted = 0) AS TotalGenres;
            ";

            return await _db.QueryFirstAsync<DashboardSummaryDto>(sql);
        }
    }
}
