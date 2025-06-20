using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class ChatViewModel
    {
        // Mexanik haqqında məlumat
        public int MechanicId { get; set; }
        public string MechanicFullName { get; set; }
        public string MechanicImageUrl { get; set; }
        public string MechanicDesignation { get; set; }

        // İstifadəçi haqqında məlumat (əgər göstərmək istəsən)
        public string? UserId { get; set; }
        public string? UserFullName { get; set; }

        // Əvvəlki mesajlar (viewdə göstərmək üçün)
        public List<ChatMessageVM> Messages { get; set; } = new List<ChatMessageVM>();
    }

}
