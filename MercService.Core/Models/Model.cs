using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
     

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<SubModelProblem> SubModelProblems { get; set; }
        public ICollection<SubModel> SubModels { get; set; }
    }
}
