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
    public class SubModelService : ISubModelService
    {
        private readonly ISubModelRepository _repository;

        public SubModelService(ISubModelRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SubModel>> GetAllAsync() => _repository.GetAllAsync();

        public Task<SubModel> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<List<SubModel>> GetByModelIdAsync(int modelId) => _repository.GetByModelIdAsync(modelId);

        public Task AddAsync(SubModel subModel) => _repository.AddAsync(subModel);

        public Task UpdateAsync(SubModel subModel) => _repository.UpdateAsync(subModel);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
