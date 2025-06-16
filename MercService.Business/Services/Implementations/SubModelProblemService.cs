using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class SubModelProblemService: ISubModelProblemService
    {

        private readonly ISubModelProblemRepository _repository;

        public SubModelProblemService(ISubModelProblemRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubModelProblemVM> GetDetailsAsync(int modelId, int problemId)
        {
            var modelProblem = await _repository.GetByModelIdAndProblemIdAsync(modelId, problemId);
            if (modelProblem == null)
                return null;

            return new SubModelProblemVM
            {
                SubModel = modelProblem.SubModel,
                CarProblem = modelProblem.CarProblem,
                Mechanics = modelProblem.Mechanics.ToList(),
                Comments = modelProblem.Comments.OrderByDescending(c => c.CreatedAt).ToList()
            };
        }

        public async Task<IEnumerable<SubModelProblem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(SubModelProblem modelProblem)
        {
            await _repository.AddAsync(modelProblem);
        }

        public async Task UpdateAsync(SubModelProblem modelProblem)
        {
            await _repository.UpdateAsync(modelProblem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
