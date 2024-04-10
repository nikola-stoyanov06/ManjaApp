using AutoMapper;
using ManjaApp.Data.Entities;
using ManjaApp.Data.Repositories.Abstractions;
using Services.Abstractions;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICrudRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICrudRepository<Category> categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _categoryRepository.DeleteByIdAsync(id);
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = (await _categoryRepository.GetAllAsync());
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task UpdateCategoryAsync(CategoryDTO model)
        {
            var category = _mapper.Map<Category>(model);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
