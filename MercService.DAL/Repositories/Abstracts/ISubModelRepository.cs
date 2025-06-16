using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface ISubModelRepository
    {
        Task<List<SubModel>> GetAllAsync();
        Task<SubModel> GetByIdAsync(int id);
        Task<List<SubModel>> GetByModelIdAsync(int modelId);
        Task AddAsync(SubModel subModel);
        Task UpdateAsync(SubModel subModel);
        Task DeleteAsync(int id);
    }
}
