using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.DAL.Repositories.Abstracts;
using MercService.DAL.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class MechanicService:IMechanicService
    {
        private readonly IMechanicRepository _repository;

        public MechanicService(IMechanicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Mechanic> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Mechanic>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Mechanic mechanic)
        {
            await _repository.AddAsync(mechanic);
        }

        public async Task UpdateAsync(Mechanic mechanic)
        {
            await _repository.UpdateAsync(mechanic);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Mechanic?> GetByIdWithDetailsAsync(int id)
        {
            return await _repository.Mechanics
                .Include(m => m.Comments)
                .Include(m => m.ModelProblems)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<Mechanic>> GetSimilarMechanicsAsync(int mechanicId)
        {
        
            var currentMechanic = await _repository.GetByIdAsync(mechanicId);
            if (currentMechanic == null) return new List<Mechanic>();

            var similarMechanics = await _repository.GetAllAsync();
            return similarMechanics
                .Where(m => m.Designation == currentMechanic.Designation && m.Id != mechanicId)
                .ToList();
        }

    }
}
