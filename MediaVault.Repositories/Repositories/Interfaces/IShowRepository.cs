using MediaVault.Models.Entities;

namespace MediaVault.Repositories.Interfaces
{
    public interface IShowRepository
    {
        IEnumerable<Show> GetAll();
        Show? GetById(int id);
        void Add(Show show);
        void Update(Show show);
        void Delete(int id);
        bool Exists(int id);
    }
}
