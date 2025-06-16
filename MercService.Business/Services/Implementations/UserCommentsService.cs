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
    public class UserCommentsService:IUserCommentsService
    {
        private readonly IUserCommentsRepository _repository;

        public UserCommentsService(IUserCommentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserComments>> GetByModelProblemIdAsync(int modelProblemId)
        {
            return await _repository.GetByModelProblemIdAsync(modelProblemId);
        }

        public async Task<UserComments> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(UserComments comment)
        {
            await _repository.AddAsync(comment);
        }

        public async Task UpdateAsync(UserComments comment)
        {
            await _repository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
