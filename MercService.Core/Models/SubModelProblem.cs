using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class SubModelProblem
    {
        public int Id { get; set; }

        // Hansi modeldə bu problem var
        public int SubModelId { get; set; }
        public SubModel SubModel { get; set; }
        public int CarProblemId { get; set; }
        public CarProblem CarProblem { get; set; }
        public ICollection<Mechanic> Mechanics { get; set; }
        public ICollection<UserComments> Comments { get; set; }
       

      


    }
}
