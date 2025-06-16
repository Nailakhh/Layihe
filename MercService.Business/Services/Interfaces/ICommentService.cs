using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(UserComments comment);
        Task<UserComments?> GetCommentByIdAsync(int commentId);
        Task<List<UserComments>> GetCommentsByMechanicIdAsync(int mechanicId);
        Task<int> GetLikeCountAsync(int commentId);
        Task<bool> UserHasLikedAsync(int commentId, string userId);
        Task<bool> ToggleLikeAsync(int commentId, string userId);
    }
}
