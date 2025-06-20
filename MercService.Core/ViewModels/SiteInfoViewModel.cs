using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class SiteInfoViewModel
    {
        public ContactInfo ContactInfo { get; set; }
        public List<SocialLink> SocialLinks { get; set; }
        public List<Location> Locations { get; set; }
        public ContactInfo NewContact { get; set; }
    }

}
