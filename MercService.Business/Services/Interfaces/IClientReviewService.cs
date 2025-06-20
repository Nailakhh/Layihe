using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface IClientReviewService
    {
        Task<List<ClientReview>> GetAllApprovedAsync();
        Task<List<ClientReview>> GetAllAsync();
        Task AddReviewAsync(ClientReview review);
        Task ApproveReviewAsync(int id);
        Task DeleteReviewAsync(int id);
    }

}
