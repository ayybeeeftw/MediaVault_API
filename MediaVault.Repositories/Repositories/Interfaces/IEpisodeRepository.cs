using MediaVault.Models.Entities;

namespace MediaVault.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        IEnumerable<Episode> GetAll();
        Episode? GetById(int id);
        void Add(Episode episode);
        void Update(Episode episode);
        void Delete(int id);
        bool Exists(int id);
    }
}
