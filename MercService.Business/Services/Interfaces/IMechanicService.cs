using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface IMechanicService
    {
        Task<Mechanic> GetByIdAsync(int id);
        Task<IEnumerable<Mechanic>> GetAllAsync();
        Task AddAsync(Mechanic mechanic);
        Task UpdateAsync(Mechanic mechanic);
        Task DeleteAsync(int id);

        Task<Mechanic?> GetByIdWithDetailsAsync(int id);
        Task<List<Mechanic>> GetSimilarMechanicsAsync(int mechanicId);
    }
}
