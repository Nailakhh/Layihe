using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Repositories.Abstracts;
using MercService.DAL.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        private static readonly List<string> ForbiddenWords = new List<string>
        {
            "pissoz1",
            "tehqir1",
            "soyus1",
        };

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<bool> AddCommentAsync(UserComments comment)
        {
            if (ContainsForbiddenWords(comment.Text))
                return false;

            await _commentRepository.AddCommentAsync(comment);
            return true;
        }

        private bool ContainsForbiddenWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            var lowered = text.ToLower();
            return ForbiddenWords.Any(word => lowered.Contains(word));
        }

        public async Task<UserComments?> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task<List<UserComments>> GetCommentsByMechanicIdAsync(int mechanicId)
        {
            return await _commentRepository.GetCommentsByMechanicIdAsync(mechanicId);
        }

        public async Task<int> GetLikeCountAsync(int commentId)
        {
            return await _commentRepository.GetLikeCountAsync(commentId);
        }

        public async Task<bool> ToggleLikeAsync(int commentId, string userId)
        {
            return await _commentRepository.ToggleLikeAsync(commentId, userId);
        }

        public async Task<bool> UserHasLikedAsync(int commentId, string userId)
        {
            return await _commentRepository.UserHasLikedAsync(commentId, userId);
        }

        // ** İndi currentUserId parametrini əlavə et **
        public async Task<List<CommentViewModel>> GetCommentsWithUserByMechanicIdAsync(int mechanicId, string currentUserId)
        {
            var comments = await _commentRepository.GetCommentsWithUserByMechanicIdAsync(mechanicId);

            var commentVMs = comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                Text = c.Text,
                CreatedAt = c.CreatedAt,
                Rating = c.Rating,
                LikesCount = c.Likes?.Count ?? 0,
                IsLikedByCurrentUser = c.Likes?.Any(l => l.AppUserId == currentUserId) ?? false,
                AppUserFullName = !string.IsNullOrWhiteSpace(c.AppUser?.FullName) ? c.AppUser.FullName : "Anonim",
                UserName = c.AppUser?.UserName ?? "Anonim",
                AppUserEmail = c.AppUser?.Email ?? "",
                UserAvatarUrl = !string.IsNullOrWhiteSpace(c.AppUser?.AvatarUrl)
                    ? c.AppUser.AvatarUrl
                    : "/assets/img/user.png"
            }).ToList();

            return commentVMs;
        }
    }
}