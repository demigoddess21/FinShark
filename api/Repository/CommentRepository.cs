using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comments> CreateAsync(Comments CommentsModel)
        {
            await _context.Comments.AddAsync(CommentsModel);
            await _context.SaveChangesAsync();
            return CommentsModel;

        }

        public async Task<Comments?> DeleteAsync(int id)
        {
            var CommentsModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (CommentsModel == null)
            {
                return null;
            }


            _context.Comments.Remove(CommentsModel);
            await _context.SaveChangesAsync();
            return CommentsModel;
        }

        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comments?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comments?> UpdateAsync(int id, UpdateCommentRequestDto updateDto)
        {
            var existingComments = await _context.Comments.FindAsync(id);

            if (existingComments == null)
            {
                return null;
            }

            existingComments.Title = updateDto.Title;
            existingComments.Content = updateDto.Content;
            await _context.SaveChangesAsync();
            return existingComments;

        }
    }
}