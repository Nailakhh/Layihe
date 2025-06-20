using MercService.Core.Models;
using MercService.Core.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class MechanicVM
    {
        public int Id { get; set; }
        public List<Mechanic>? Mechanics { get; set; }

        [Required(ErrorMessage = "Ad və soyad tələb olunur")]
        public string FullName { get; set; }

       
        [Required(ErrorMessage = "Peşə adı tələb olunur")]
        public string Designation { get; set; }

        public IFormFile? File { get; set; }
        public string? ExistingImageUrl { get; set; }
        [LowercaseOnly(ErrorMessage = "Yalnız kiçik hərflərlə daxil edin")]
        public string? FacebookUrl { get; set; }
        [LowercaseOnly(ErrorMessage = "Yalnız kiçik hərflərlə daxil edin")]
        public string? TwitterUrl { get; set; }
        [LowercaseOnly(ErrorMessage = "Yalnız kiçik hərflərlə daxil edin")]
        public string InstagramUrl { get; set; }
   

        [Range(0, 100, ErrorMessage = "Təcrübə ili 0 ilə 70 arasında olmalıdır")]
        public double? ExperienceYear { get; set; }
        public DateTime? CreatedAt { get; set; }

        public double? AverageRating { get; set; } // Orta reytinq (1-5 arası)

        public List<UserComments>? Comments { get; set; }
        public string? PhoneNumber { get; set; }

        public string? RepairAreas { get; set; }

        public string? Certificates { get; set; }


        public string? SearchTerm { get; set; }
   
        [Range(0, double.MaxValue, ErrorMessage = "Minimum qiymət 0 və daha böyük olmalıdır")]
        public decimal? MinPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Maksimum qiymət 0 və daha böyük olmalıdır")]
        public decimal? MaxPrice { get; set; }

        public List<MechanicVM> ChatMechanics { get; set; }


        public string FacebookName => string.IsNullOrWhiteSpace(FacebookUrl)



    ? ""
    : FacebookUrl.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();

        public string InstagramName => string.IsNullOrWhiteSpace(InstagramUrl)
            ? ""
            : InstagramUrl.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();

        public string TwitterName => string.IsNullOrWhiteSpace(TwitterUrl)
            ? ""
            : TwitterUrl.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();

    }
}
