using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int MechanicId { get; set; }     // Usta ID-si
        public string SenderId { get; set; }    // Mesajı göndərənin UserId-si
        public string Text { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
