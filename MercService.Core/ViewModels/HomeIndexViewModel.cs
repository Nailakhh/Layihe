using MercService.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class HomeIndexViewModel
    {

        public List<Category> Categories { get; set; }
        public List<Model> Models { get; set; }
        public List<CarProblem> Problems { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<Mechanic> Mechanics { get; set; }
    }
}
