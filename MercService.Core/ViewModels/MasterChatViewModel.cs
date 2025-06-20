using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class MasterChatViewModel
    {
        public List<MercService.Core.Models.Mechanic> MastersList { get; set; }
        public MercService.Core.Models.Mechanic SelectedMaster { get; set; }
    }
}
