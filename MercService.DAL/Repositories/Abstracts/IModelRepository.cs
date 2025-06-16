using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        Model GetById(int id);
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
    }
}
