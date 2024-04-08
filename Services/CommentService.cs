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
    public class CommentService : ICommentService
    {
        private readonly ICrudRepository<Comment> _repository;
        private readonly IMapper _mapper;
        public CommentService(ICrudRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddCommentAsync(CommentDTO model)
        {
            var comment = _mapper.Map<Comment>(model);
            await _repository.AddAsync(comment);
        }

        public async Task DeleteCommentByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<CommentDTO> GetCommentByIdAsync(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task<List<CommentDTO>> GetCommentsAsync()
        {
            var comments = (await _repository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<CommentDTO>>(comments);
        }

        public async Task<List<CommentDTO>> GetCommentsByRatingAsync(int rating)
        {
            var comments = (await _repository.GetAsync(item => item.Rating == rating))
                .ToList();
            return _mapper.Map<List<CommentDTO>>(comments);
        }

        public async Task UpdateCommentAsync(CommentDTO model)
        {
            var comment = _mapper.Map<Comment>(model);
            await _repository.UpdateAsync(comment);
        }
    }
}
