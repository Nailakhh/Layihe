using MercService.Core.Models;
using MercService.DAL.Context;
using MercService.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Concretes
{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _context;

        public ModelRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Model> GetAll()
        {
            return _context.Models.Include(m => m.Category).ToList();
        }

        public Model GetById(int id)
        {
            return _context.Models.Include(m => m.Category).FirstOrDefault(m => m.Id == id);
        }

        public void Add(Model model)
        {
            _context.Models.Add(model);
            _context.SaveChanges();
        }

        public void Update(Model model)
        {
            _context.Models.Update(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Models.Find(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}
