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
    public class SubModelRepository : ISubModelRepository
    {
        private readonly AppDbContext _context;

        public SubModelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubModel>> GetAllAsync()
        {
            return await _context.SubModels.Include(sm => sm.Model).ToListAsync();
        }

        public async Task<SubModel> GetByIdAsync(int id)
        {
            return await _context.SubModels.Include(sm => sm.Model)
                .FirstOrDefaultAsync(sm => sm.Id == id);
        }

        public async Task<List<SubModel>> GetByModelIdAsync(int modelId)
        {
            return await _context.SubModels.Where(sm => sm.ModelId == modelId).ToListAsync();
        }

        public async Task AddAsync(SubModel subModel)
        {
            await _context.SubModels.AddAsync(subModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubModel subModel)
        {
            _context.SubModels.Update(subModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SubModels.FindAsync(id);
            if (entity != null)
            {
                _context.SubModels.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
