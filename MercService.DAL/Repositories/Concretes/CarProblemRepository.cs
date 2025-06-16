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
    public class CarProblemRepository : ICarProblemRepository
    {
        private readonly AppDbContext _context;

        public CarProblemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarProblem>> GetAllAsync()
        {
            return await _context.CarProblems
                .Include(cp => cp.SubModelProblems)
                    .ThenInclude(mp => mp.SubModel)
                .ToListAsync();
        }

        public async Task<CarProblem> GetByIdAsync(int id)
        {
            return await _context.CarProblems
                .Include(cp => cp.SubModelProblems)
                    .ThenInclude(mp => mp.SubModel)
                .FirstOrDefaultAsync(cp => cp.Id == id);
        }

        public async Task AddAsync(CarProblem carProblem)
        {
            _context.CarProblems.Add(carProblem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarProblem carProblem)
        {
            _context.CarProblems.Update(carProblem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CarProblems.FindAsync(id);
            if (entity != null)
            {
                _context.CarProblems.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
