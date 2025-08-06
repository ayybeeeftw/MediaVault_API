using MediaVault.Repositories.Data;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;

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
    }
}
