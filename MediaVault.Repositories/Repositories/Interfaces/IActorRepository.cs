using MediaVault.Models.Entities;

namespace MediaVault.Repositories.Interfaces
{
    public interface IActorRepository
    {
        IEnumerable<Actor> GetAll();
        Actor? GetById(int id);
        void Add(Actor actor);
        void Update(Actor actor);
        void Delete(int id);
        bool Exists(int id);
    }
}
