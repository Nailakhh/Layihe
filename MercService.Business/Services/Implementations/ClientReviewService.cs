using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class ClientReviewService : IClientReviewService
    {
        private readonly IClientReviewRepository _repository;

        public ClientReviewService(IClientReviewRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ClientReview>> GetAllApprovedAsync()
            => _repository.GetAllApprovedAsync();

        public async Task AddReviewAsync(ClientReview review)
        {
            review.IsApproved = false;
            review.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _repository.AddAsync(review);
        }

        public async Task ApproveReviewAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review != null)
            {
                review.IsApproved = true;
                await _repository.UpdateAsync(review);
            }
        }

        public Task DeleteReviewAsync(int id)
            => _repository.DeleteAsync(id);

        public async Task<List<ClientReview>> GetAllAsync()
            => await _repository.GetAllAsync();
    }
}