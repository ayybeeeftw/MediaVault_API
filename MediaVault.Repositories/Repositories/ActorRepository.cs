using MediaVault.Repositories.Data;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;

namespace MediaVault.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Actor> GetAll()
        {
            return _context.Actors.ToList(); // filtering is handled in Service
        }

        public Actor? GetById(int id)
        {
            return _context.Actors.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Actor actor)
        {
            actor.IsDeleted = false;
            _context.Actors.Add(actor);
            _context.SaveChanges(); // 🔁 commit to DB
        }

        public void Update(Actor actor)
        {
            _context.Actors.Update(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var actor = GetById(id);
            if (actor != null)
            {
                actor.IsDeleted = true;
                _context.Actors.Update(actor);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Actors.Any(a => a.Id == id);
        }
    }
}
