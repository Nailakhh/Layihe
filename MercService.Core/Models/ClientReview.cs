using MercService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class ClientReview
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Müştərinin adı
        public string?  Profession { get; set; }  // Müştərinin işi / peşəsi
        public string Comment { get; set; }     // Rəy / şərh
        public string? ImageUrl { get; set; }    // Müştərinin şəkil URL-i
        public bool IsApproved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(4);
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }


    }

}
