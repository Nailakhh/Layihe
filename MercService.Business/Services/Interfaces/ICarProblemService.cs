using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface ICarProblemService
    {
        Task<List<CarProblem>> GetAllProblemsAsync();
        Task<CarProblem> GetByIdAsync(int id);
        Task AddAsync(CarProblem problem);
        Task UpdateAsync(CarProblem problem);
        Task DeleteAsync(int id);
    }
}
