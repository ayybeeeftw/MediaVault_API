using MediaVault.Repositories.Data;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;

namespace MediaVault.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly AppDbContext _context;

        public EpisodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Episode> GetAll()
        {
            return _context.Episodes.ToList(); // Service layer handles filtering
        }

        public Episode? GetById(int id)
        {
            return _context.Episodes.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Episode episode)
        {
            episode.IsDeleted = false;
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }

        public void Update(Episode episode)
        {
            _context.Episodes.Update(episode);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var episode = GetById(id);
            if (episode != null)
            {
                episode.IsDeleted = true;
                _context.Episodes.Update(episode);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Episodes.Any(e => e.Id == id);
        }
    }
}
