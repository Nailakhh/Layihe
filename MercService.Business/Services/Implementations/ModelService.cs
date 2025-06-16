using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class ModelService:IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public List<Model> GetAllModels()
        {
            return _modelRepository.GetAll();
        }

        public Model GetById(int id)
        {
            return _modelRepository.GetById(id);
        }

        public void Add(Model model)
        {
            _modelRepository.Add(model);
        }

        public void Update(Model model)
        {
            _modelRepository.Update(model);
        }

        public void Delete(int id)
        {
            _modelRepository.Delete(id);
        }
    }
}
