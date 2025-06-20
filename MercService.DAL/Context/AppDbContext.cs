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

        public DbSet<CarProblem> CarProblems { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<UserComments> UserComments { get; set; }
        public DbSet<SubModelProblem> SubModelProblems { get; set; }
        public DbSet<SubModel> SubModels { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CommentLikes> CommentLikes { get; set; }
        public DbSet<ClientReview> ClientReviews { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // UserComments - AppUser
            builder.Entity<UserComments>()
                .HasOne(c => c.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // CommentLikes - AppUser
            builder.Entity<CommentLikes>()
                .HasOne(like => like.AppUser)
                .WithMany(u => u.CommentLikes)
                .HasForeignKey(like => like.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ CommentLikes - UserComment (ƏLAVƏ ETDİYİMİZ ƏLAQƏ)
            builder.Entity<CommentLikes>()
                .HasOne(cl => cl.UserComment)
                .WithMany(c => c.Likes)
                .HasForeignKey(cl => cl.UserCommentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Model - SubModel
            builder.Entity<Model>()
                .HasMany(m => m.SubModels)
                .WithOne(sm => sm.Model)
                .HasForeignKey(sm => sm.ModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }




}

