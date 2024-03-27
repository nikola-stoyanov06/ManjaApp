using ManjaApp.Data.Entities;
using ManjaApp.Data.Repositories.Abstractions;
using Services.Abstractions;

namespace Services
{
    public class ManjaService : IManjaService
    {
        private readonly ICrudRepository<Manja> _repository;
        public ManjaService(ICrudRepository<Manja> repository)
        {
            _repository = repository;
        }
        public async Task AddManjaAsync(Manja manja)
        {
            await _repository.AddAsync(manja);
        }

        public async Task DeleteManjaByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<Manja> GetManjaByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Manja>> GetManjasAsync()
        {
            return (await _repository.GetAllAsync())
                .ToList();
        }

        public async Task<List<Manja>> GetManjasByNameAsync(string name)
        {
            return (await _repository.GetAsync(item => item.Title == name)).ToList();
        }

        public async Task UpdateManjaAsync(Manja manja)
        {
            await _repository.UpdateAsync(manja);
        }
    }
}