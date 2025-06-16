using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string? ImageUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public ICollection<UserComments>? Comments { get; set; }


        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow.AddHours(4);

        public double? ExperienceYear { get; set; }
        public string? PhoneNumber { get; set; }

        public string? RepairAreas { get; set; }

        // Qiymət aralığı üçün iki sahə
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public string? Certificates { get; set; }
        public double? AverageRating { get; set; }

        public string FacebookName => string.IsNullOrWhiteSpace(FacebookUrl)
    ? ""
    : FacebookUrl.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();

        public string InstagramName => string.IsNullOrWhiteSpace(InstagramUrl)
            ? ""
            : InstagramUrl.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();

        public string TwitterName => string.IsNullOrWhiteSpace(TwitterUrl)
            ? ""
            : TwitterUrl.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();

        public ICollection<SubModelProblem> ModelProblems { get; set; }
    }
}
