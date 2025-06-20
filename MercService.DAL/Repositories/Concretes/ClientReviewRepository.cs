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
    public class ClientReviewRepository : IClientReviewRepository
    {
        private readonly AppDbContext _dbContext;

        public ClientReviewRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClientReview>> GetAllAsync()
        {
            return await _dbContext.ClientReviews.ToListAsync();
        }

        public async Task<List<ClientReview>> GetAllApprovedAsync()
        {
            return await _dbContext.ClientReviews
                .Include(r => r.AppUser)
                .Where(r => r.IsApproved)
                .ToListAsync();
        }


        public async Task<ClientReview?> GetByIdAsync(int id)
        {
            return await _dbContext.ClientReviews.FindAsync(id);
        }

        public async Task AddAsync(ClientReview review)
        {
            await _dbContext.ClientReviews.AddAsync(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClientReview review)
        {
            _dbContext.ClientReviews.Update(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _dbContext.ClientReviews.FindAsync(id);
            if (review != null)
            {
                _dbContext.ClientReviews.Remove(review);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}