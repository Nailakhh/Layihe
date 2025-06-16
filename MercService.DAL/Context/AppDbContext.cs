using MercService.Core.Entities;
using MercService.Core.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MercService.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<CarProblem> CarProblems { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<UserComments> UserComments { get; set; }
        public DbSet<SubModelProblem> SubModelProblems { get; set; }
        public DbSet<SubModel> SubModels { get; set; }

        public DbSet<CommentLikes> CommentLikes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Model ilə SubModel arasında 1-n əlaqəsi
            builder.Entity<Model>()
                .HasMany(m => m.SubModels)
                .WithOne(sm => sm.Model)
                .HasForeignKey(sm => sm.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Əlavə konfiqurasiyalar buraya
        }

    }




}

