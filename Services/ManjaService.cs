using AutoMapper;
using ManjaApp.Data.Entities;
using ManjaApp.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;
using Services.DTOs;

namespace Services
{
    public class ManjaService : IManjaService
    {
        private readonly IManjaRepository _manjaRepository;
        private readonly IMapper _mapper;
        private readonly ICrudRepository<Category>
            _categoryRepository;
        
        public ManjaService(IManjaRepository manjaRepository, IMapper mapper, 
            ICrudRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _manjaRepository = manjaRepository;
            _categoryRepository = categoryRepository;
        }

        public Task AddCommentAsync(CommentCreateEditDTO comment)
        {
            throw new NotImplementedException();
        }

        public async Task AddManjaAsync(ManjaCreateEditDTO model)
        {
            var manja = _mapper.Map<Manja>(model);
            var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
            manja.Category = category;

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

        public async Task<List<ManjaDTO>> GetManjasByCategoryIdAsync(int id)
        {
            var manjas = (await _manjaRepository.GetAsync(item => item.Category.Id == id)).ToList();
            return _mapper.Map<List<ManjaDTO>>(manjas);
        }

        public async Task<List<ManjaDTO>> GetManjasByUserIdAsync(string id)
        {
            var manjas = (await _manjaRepository.GetAsync(item => item.UserId == id)).ToList();
            return _mapper.Map<List<ManjaDTO>>(manjas);
        }

        public async Task UpdateManjaAsync(ManjaCreateEditDTO model)
        {
            var manja = _mapper.Map<Manja>(model);
            var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
            manja.Category = category;
            await _manjaRepository.UpdateManja(manja, category);
        }
    }
}