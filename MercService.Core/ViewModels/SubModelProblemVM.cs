using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class SubModelProblemVM
    {
        public SubModel SubModel { get; set; }

        // Seçilmiş ümumi problem
        public CarProblem CarProblem { get; set; }

        // Model və problemə aid ustalar
        public List<Mechanic> Mechanics { get; set; }

        // İstifadəçi rəyləri
        public List<UserComments> Comments { get; set; }
    }
}
