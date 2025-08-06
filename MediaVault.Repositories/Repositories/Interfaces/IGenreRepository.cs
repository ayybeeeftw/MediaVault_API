using MediaVault.Models.Entities;

namespace MediaVault.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        Genre? GetById(int id);
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(int id);
        bool Exists(int id);
    }
}
