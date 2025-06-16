using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MercService.Core.ViewModels
{
    public class SearchViewModel
    {
        public int SelectedCategoryId { get; set; }
        public int SelectedModelId { get; set; }
        public int SelectedProblemId { get; set; }

        public List<Category> Categories { get; set; }
        public List<Model> Models { get; set; }
        public List<CarProblem> Problems { get; set; }

        // Nəticələr:
        public List<Mechanic> Mechanics { get; set; }
        public List<UserComments> Comments { get; set; }
        public int? SelectedYear { get; set; }  // İlin seçimi opsionaldır, nullable

        public List<SelectListItem> Years { get; set; }

        public List<SubModel> SubModels { get; set; }
        public int SelectedSubModelId { get; set; }

    }
}
