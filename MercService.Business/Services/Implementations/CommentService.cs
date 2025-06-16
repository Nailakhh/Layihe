using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
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

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddCommentAsync(UserComments comment)
        {
            await _commentRepository.AddCommentAsync(comment);
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
            // Implementasiyanı buraya yaz
            throw new NotImplementedException();
        }

        public async Task<bool> UserHasLikedAsync(int commentId, string userId)
        {
            return await _commentRepository.UserHasLikedAsync(commentId, userId);
        }
    }
}