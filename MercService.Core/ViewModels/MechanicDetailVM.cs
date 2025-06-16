using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class MechanicDetailVM
    {
        public Mechanic Mechanic { get; set; }

   
        public List<string>? RelatedModels { get; set; }

        public bool IsFavoritedByUser { get; set; }

        public string? NewCommentText { get; set; }
        public List<Mechanic>? SimilarMechanics { get; set; }

      
        public string? NewComment { get; set; }
        public List<UserComments> Comments { get; set; }
       
    }
}
