﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class SubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }


        public ICollection<SubModelProblem> SubModelProblems { get; set; }
    }
}
