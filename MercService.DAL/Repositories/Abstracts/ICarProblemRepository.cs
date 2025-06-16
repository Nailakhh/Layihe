using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface ICarProblemRepository
    {
        Task<List<CarProblem>> GetAllAsync();
        Task<CarProblem> GetByIdAsync(int id);
        Task AddAsync(CarProblem carProblem);
        Task UpdateAsync(CarProblem carProblem);
        Task DeleteAsync(int id);

    }
}
