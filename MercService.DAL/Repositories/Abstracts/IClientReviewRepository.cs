using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface IClientReviewRepository
    {
        Task<List<ClientReview>> GetAllAsync();
        Task<List<ClientReview>> GetAllApprovedAsync();
        Task<ClientReview?> GetByIdAsync(int id);
        Task AddAsync(ClientReview review);
        Task UpdateAsync(ClientReview review);
        Task DeleteAsync(int id);
    }

}
