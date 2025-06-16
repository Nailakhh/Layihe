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
    public class UserCommentsRepository: IUserCommentsRepository
    {
        private readonly AppDbContext _context;

        public UserCommentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserComments>> GetByModelProblemIdAsync(int modelProblemId)
        {
            return await _context.UserComments
                .Where(c => c.ModelProblemId == modelProblemId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<UserComments> GetByIdAsync(int id)
        {
            return await _context.UserComments.FindAsync(id);
        }

        public async Task AddAsync(UserComments comment)
        {
            await _context.UserComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserComments comment)
        {
            _context.UserComments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UserComments.FindAsync(id);
            if (entity != null)
            {
                _context.UserComments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
