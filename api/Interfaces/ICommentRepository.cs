using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Helpers;
using api.Model;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllAsync();
        Task<Comments?> GetByIdAsync(int id);
        Task<Comments> CreateAsync(Comments commentModel);
        Task<Comments?> UpdateAsync(int id, UpdateCommentRequestDto updateDto);
        Task<Comments?> DeleteAsync(int id);
    }
}