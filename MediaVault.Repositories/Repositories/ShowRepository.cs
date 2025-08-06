using MediaVault.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;

namespace MediaVault.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly AppDbContext _context;

        public ShowRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Show> GetAll()
        {
            return _context.Shows.Include(s => s.Genre).ToList();
        }

        public Show? GetById(int id)
        {
            return _context.Shows.Include(s => s.Genre).FirstOrDefault(s => s.Id == id);
        }


        public void Add(Show show)
        {
            show.IsDeleted = false;
            _context.Shows.Add(show);
            _context.SaveChanges();
        }

        public void Update(Show show)
        {
            _context.Shows.Update(show);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var show = GetById(id);
            if (show != null)
            {
                show.IsDeleted = true;
                _context.Shows.Update(show);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Shows.Any(s => s.Id == id);
        }
    }
}
