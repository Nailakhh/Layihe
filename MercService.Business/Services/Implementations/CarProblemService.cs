using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class CarProblemService : ICarProblemService
    {
        private readonly ICarProblemRepository _repository;

        public CarProblemService(ICarProblemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CarProblem>> GetAllProblemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CarProblem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(CarProblem problem)
        {
            await _repository.AddAsync(problem);
        }

        public async Task UpdateAsync(CarProblem problem)
        {
            await _repository.UpdateAsync(problem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
