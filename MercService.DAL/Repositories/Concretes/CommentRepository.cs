using MercService.Core.Models;
using MercService.DAL.Context;
using MercService.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MercService.DAL.Repositories.Concretes
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(UserComments comment)
        {
            _context.UserComments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<UserComments?> GetCommentByIdAsync(int commentId)
        {
            return await _context.UserComments.FindAsync(commentId);
        }

        public async Task<List<UserComments>> GetCommentsByMechanicIdAsync(int mechanicId)
        {
            return await _context.UserComments
                .Where(c => c.MechanicId == mechanicId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetLikeCountAsync(int commentId)
        {
            return await _context.CommentLikes.CountAsync(l => l.UserCommentId == commentId);
        }

        public async Task<bool> UserHasLikedAsync(int commentId, string userId)
        {
            return await _context.CommentLikes.AnyAsync(l => l.UserCommentId == commentId && l.AppUserId == userId);
        }

        public async Task ToggleLikeAsync(int commentId, string userId)
        {
            var like = await _context.CommentLikes.FirstOrDefaultAsync(l => l.UserCommentId == commentId && l.AppUserId == userId);

            if (like != null)
            {
                _context.CommentLikes.Remove(like);
            }
            else
            {
                _context.CommentLikes.Add(new CommentLikes
                {
                    UserCommentId = commentId,
                    AppUserId = userId
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}