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
    public class MechanicRepository :IMechanicRepository
    {
        private readonly AppDbContext _context;

       

        public MechanicRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Mechanic> Mechanics => _context.Mechanics;

        public async Task<Mechanic> GetByIdAsync(int id)
        {
            return await _context.Mechanics.FindAsync(id);
        }

        public async Task<IEnumerable<Mechanic>> GetAllAsync()
        {
            return await _context.Mechanics.ToListAsync();
        }

        public async Task AddAsync(Mechanic mechanic)
        {
            await _context.Mechanics.AddAsync(mechanic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mechanic mechanic)
        {
            _context.Mechanics.Update(mechanic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Mechanics.FindAsync(id);
            if (entity != null)
            {
                _context.Mechanics.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Mechanic>> GetSimilarMechanicsByDesignationAsync(string designation, int excludeMechanicId)
        {
            return await _context.Mechanics
                .Where(m => m.Designation == designation && m.Id != excludeMechanicId)
                .ToListAsync();
        }
    }
}
