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
    public class SubModelProblemRepository : ISubModelProblemRepository

    {

        private readonly AppDbContext _context;

        public SubModelProblemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubModelProblem> GetByModelIdAndProblemIdAsync(int modelId, int problemId)
        {
            return await _context.SubModelProblems
                .Include(mp => mp.SubModel)
                .Include(mp => mp.CarProblem)
                .Include(mp => mp.Mechanics)
                .Include(mp => mp.Comments)
                .FirstOrDefaultAsync(mp => mp.SubModelId == modelId && mp.CarProblemId == problemId);
        }

        public async Task<IEnumerable<SubModelProblem>> GetAllAsync()
        {
            return await _context.SubModelProblems
                .Include(mp => mp.SubModel)
                .Include(mp => mp.CarProblem)
                .ToListAsync();
        }

        public async Task AddAsync(SubModelProblem modelProblem)
        {
            await _context.SubModelProblems.AddAsync(modelProblem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubModelProblem modelProblem)
        {
            _context.SubModelProblems.Update(modelProblem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SubModelProblems.FindAsync(id);
            if (entity != null)
            {
                _context.SubModelProblems.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
