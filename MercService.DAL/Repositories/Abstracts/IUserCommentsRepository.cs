using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface IUserCommentsRepository
    {
        Task<IEnumerable<UserComments>> GetByModelProblemIdAsync(int modelProblemId);
        Task<UserComments> GetByIdAsync(int id);
        Task AddAsync(UserComments comment);
        Task UpdateAsync(UserComments comment);
        Task DeleteAsync(int id);
    }
}
