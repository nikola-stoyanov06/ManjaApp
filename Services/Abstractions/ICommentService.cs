using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICommentService
    {
        Task<List<CommentDTO>> GetCommentsAsync();
        Task<CommentDTO> GetCommentByIdAsync(int id);
        Task<List<CommentDTO>> GetCommentsByRatingAsync(int rating);
        Task AddCommentAsync(CommentDTO model);
        Task DeleteCommentByIdAsync(int id);
        Task UpdateCommentAsync(CommentDTO model);
    }
}
