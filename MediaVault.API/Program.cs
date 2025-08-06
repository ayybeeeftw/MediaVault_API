using MediaVault.Repositories.Data;
using Microsoft.EntityFrameworkCore;

// Repositories
using MediaVault.Repositories;
using MediaVault.Repositories.Interfaces;

// Services
using MediaVault.Services;
using MediaVault.Services.Interfaces;

namespace TestProject_API
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
