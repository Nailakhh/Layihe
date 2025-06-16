using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface IMechanicRepository
    {
        Task<Mechanic> GetByIdAsync(int id);
        Task<IEnumerable<Mechanic>> GetAllAsync();
        Task AddAsync(Mechanic mechanic);
        Task UpdateAsync(Mechanic mechanic);
        Task DeleteAsync(int id);
        IQueryable<Mechanic> Mechanics { get; }
        Task<List<Mechanic>> GetSimilarMechanicsByDesignationAsync(string designation, int excludeMechanicId);
    }
}
