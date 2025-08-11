// Repositories
using MediaVault.Repositories;
using MediaVault.Repositories.Data;
using MediaVault.Repositories.Interfaces;
// Services
using MediaVault.Services;
using MediaVault.Services.Dapper;
using MediaVault.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MediaVault.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ---------------------------
            // Add Services to the Container
            // ---------------------------

            // Register DbContext with SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            builder.Services.AddScoped<IShowRepository, ShowRepository>();
            builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();

            // Services
            builder.Services.AddScoped<IShowService, ShowService>();
            builder.Services.AddScoped<IEpisodeService, EpisodeService>();
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<DapperShowService>();
            builder.Services.AddScoped<DapperDashboardService>();

            // Controllers
            builder.Services.AddControllers();

            // Swagger / API Explorer
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ---------------------------
            // Configure the HTTP Pipeline
            // ---------------------------

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
