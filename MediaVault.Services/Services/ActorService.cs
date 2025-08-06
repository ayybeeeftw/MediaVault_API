using MediaVault.Models.DTOs.Actors;
using MediaVault.Models.Entities;
using MediaVault.Repositories.Interfaces;
using MediaVault.Services.Interfaces;

namespace MediaVault.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repository;

        public ActorService(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ActorDto>> GetAllAsync()
        {
            var actors = _repository.GetAll()
                .Where(a => !a.IsDeleted) // ✅ manually exclude deleted
                .Select(a => new ActorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography,
                    BirthDate = a.BirthDate,
                    Gender = a.Gender,
                    Nationality = a.Nationality
                });

            return await Task.FromResult(actors);
        }

        public async Task<ActorDto?> GetByIdAsync(int id)
        {
            var actor = _repository.GetById(id);
            if (actor == null || actor.IsDeleted) return null;

            var dto = new ActorDto
            {
                Id = actor.Id,
                Name = actor.Name,
                Biography = actor.Biography,
                BirthDate = actor.BirthDate,
                Gender = actor.Gender,
                Nationality = actor.Nationality
            };

            return await Task.FromResult(dto);
        }

        public async Task<ActorDto> CreateAsync(CreateActorDto dto)
        {
            var actor = new Actor
            {
                Name = dto.Name,
                Biography = dto.Biography,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                Nationality = dto.Nationality
            };

            _repository.Add(actor);

            var result = new ActorDto
            {
                Id = actor.Id,
                Name = actor.Name,
                Biography = actor.Biography,
                BirthDate = actor.BirthDate,
                Gender = actor.Gender,
                Nationality = actor.Nationality
            };

            return await Task.FromResult(result);
        }
        public async Task<bool> UpdateAsync(int id, UpdateActorDto dto)
        {
            var actor = _repository.GetById(id);
            if (actor == null || actor.IsDeleted) return await Task.FromResult(false);

            actor.Name = dto.Name;
            actor.Biography = dto.Biography;
            actor.BirthDate = dto.BirthDate;
            actor.Gender = dto.Gender;
            actor.Nationality = dto.Nationality;

            _repository.Update(actor);
            return await Task.FromResult(true);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var actor = _repository.GetById(id);
            if (actor == null || actor.IsDeleted) return await Task.FromResult(false);

            actor.IsDeleted = true;
            _repository.Update(actor);  // using update instead of delete
            return await Task.FromResult(true);
        }

    }
}
