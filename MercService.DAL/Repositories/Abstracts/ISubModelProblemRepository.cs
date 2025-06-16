using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface ISubModelProblemRepository
    {
        Task<SubModelProblem> GetByModelIdAndProblemIdAsync(int modelId, int problemId);
        Task<IEnumerable<SubModelProblem>> GetAllAsync();
        Task AddAsync(SubModelProblem modelProblem);
        Task UpdateAsync(SubModelProblem modelProblem);
        Task DeleteAsync(int id);
    }
}
