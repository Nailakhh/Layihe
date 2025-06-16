using MercService.Core.Models;
using MercService.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface ISubModelProblemService
    {
        Task<SubModelProblemVM> GetDetailsAsync(int modelId, int problemId);
        Task<IEnumerable<SubModelProblem>> GetAllAsync();
        Task AddAsync(SubModelProblem modelProblem);
        Task UpdateAsync(SubModelProblem modelProblem);
        Task DeleteAsync(int id);
    }
}
