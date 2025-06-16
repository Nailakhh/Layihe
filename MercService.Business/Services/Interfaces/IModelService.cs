using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface IModelService
    {
        List<Model> GetAllModels();
        Model GetById(int id);
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
    }
}
