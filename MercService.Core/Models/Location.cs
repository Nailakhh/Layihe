using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }      // Məsələn: "Baş Ofis", "Servis Mərkəzi"
        public string Address { get; set; }   // Ünvan (məs. "Babek pros. 1145, Bakı")
        public double Latitude { get; set; }  // Google Maps üçün enlik
        public double Longitude { get; set; } // Google Maps üçün uzunluq
    }
}
