using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class CarProblem
    {

        public int Id { get; set; }
        public string Title { get; set; } // Məsələn: "Mühərrik qızır", "Faralar işləmir"

        public ICollection<SubModelProblem> SubModelProblems { get; set; }
    }
}
