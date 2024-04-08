using AutoMapper;
using ManjaApp.Data.Entities;
using ManjaApp.Data.Repositories.Abstractions;
using Services.Abstractions;
using Services.DTOs;

namespace Services
{
    public class ManjaService : IManjaService
    {
        private readonly ICrudRepository<Manja> _manjaRepository;
        private readonly IMapper _mapper;
        public ManjaService(ICrudRepository<Manja> manjaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _manjaRepository = manjaRepository;
        }
        public async Task AddManjaAsync(ManjaCreateEditDTO model)
        {
            var manja = _mapper.Map<Manja>(model);
            await _manjaRepository.AddAsync(manja);
        }
        
        public async Task DeleteManjaByIdAsync(int id)
        {
            await _manjaRepository.DeleteByIdAsync(id);
        }

        public async Task<ManjaDTO> GetManjaByIdAsync(int id)
        {
            var manja = await _manjaRepository.GetByIdAsync(id);
            return _mapper.Map<ManjaDTO>(manja);
        }
        public async Task<ManjaCreateEditDTO> GetManjaByIdEditAsync(int id)
        {
            var manja = await _manjaRepository
                .GetByIdAsync(id);
            return _mapper.Map<ManjaCreateEditDTO>(manja);
        }

        public async Task<List<ManjaDTO>> GetManjasAsync()
        {
            var manjas = (await _manjaRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<ManjaDTO>>(manjas);
        }

        public async Task<List<ManjaDTO>> GetManjasByNameAsync(string name)
        {
            var manjas = (await _manjaRepository.GetAsync(item => item.Title == name)).ToList();
            return _mapper.Map<List<ManjaDTO>>(manjas);
        }

        public async Task UpdateManjaAsync(ManjaCreateEditDTO model)
        {
            var manja = _mapper.Map<Manja>(model);
            await _manjaRepository.UpdateAsync(manja);
        }
    }
}