using MercService.Core.Models;
using MercService.DAL.Context;
using MercService.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await _context.UserComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<UserComments?> GetCommentByIdAsync(int commentId)
        {
            return await _context.UserComments
                .Include(c => c.AppUser)
                .Include(c => c.Likes)
                .FirstOrDefaultAsync(c => c.Id == commentId);
        }

        public async Task<List<UserComments>> GetCommentsByMechanicIdAsync(int mechanicId)
        {
            return await _context.UserComments
                .Where(c => c.MechanicId == mechanicId)
                .ToListAsync();
        }

        public async Task<int> GetLikeCountAsync(int commentId)
        {
            return await _context.CommentLikes
                .CountAsync(l => l.UserCommentId == commentId);
        }

        public async Task<bool> UserHasLikedAsync(int commentId, string userId)
        {
            return await _context.CommentLikes
                .AnyAsync(l => l.UserCommentId == commentId && l.AppUserId == userId);
        }

        public async Task<bool> ToggleLikeAsync(int commentId, string userId)
        {
            var existingLike = await _context.CommentLikes
                .FirstOrDefaultAsync(l => l.UserCommentId == commentId && l.AppUserId == userId);

            if (existingLike != null)
            {
                _context.CommentLikes.Remove(existingLike);
                await _context.SaveChangesAsync();
                return false; // Like silindi (Unlike)
            }
            else
            {
                await AddLikeAsync(commentId, userId);
                return true; // Like əlavə olundu
            }
        }

        public async Task AddLikeAsync(int commentId, string userId)
        {
            var newLike = new CommentLikes
            {
                UserCommentId = commentId,
                AppUserId = userId
            };

            await _context.CommentLikes.AddAsync(newLike);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikeAsync(int commentId, string userId)
        {
            var like = await _context.CommentLikes
                .FirstOrDefaultAsync(l => l.UserCommentId == commentId && l.AppUserId == userId);

            if (like != null)
            {
                _context.CommentLikes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserComments>> GetCommentsWithUserByMechanicIdAsync(int mechanicId)
        {
            return await _context.UserComments
                .Where(c => c.MechanicId == mechanicId)
                .Include(c => c.AppUser) // İstifadəçi məlumatları üçün
                .Include(c => c.Likes)   // Like məlumatları üçün
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }
    }
}
