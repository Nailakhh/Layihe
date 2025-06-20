using Microsoft.EntityFrameworkCore;
using System;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Identity;
using MercService.DAL.Repositories.Abstracts;
using MercService.Business.Services.Interfaces;
using MercService.Business.Services.Implementations;
using MercService.DAL.Repositories.Concretes;
using MercService.Core.Entities;
using MercService.Hubs;
namespace MercService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDbContext>(options =>

               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireUppercase = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedAccount = false;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            //            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            //            {
            //                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //                opt.User.RequireUniqueEmail = true;

            //                opt.Password.RequireDigit = true;
            //                opt.Password.RequireLowercase = true;
            //                opt.Password.RequireUppercase = true;
            //                opt.Password.RequireNonAlphanumeric = false;
            //                opt.Password.RequiredLength = 6;

            //                opt.SignIn.RequireConfirmedEmail = true; // Tövsiyə olunur
            //                opt.SignIn.RequireConfirmedAccount = true; // Tövsiyə olunur

            //                opt.Lockout.AllowedForNewUsers = true;
            //                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //                opt.Lockout.MaxFailedAccessAttempts = 5;

            //            })
            //.AddEntityFrameworkStores<AppDbContext>()
            //.AddDefaultTokenProviders();
        


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<ICarProblemRepository, CarProblemRepository>();
            builder.Services.AddScoped<ICarProblemService, CarProblemService>();

            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IModelService, ModelService>();

            builder.Services.AddScoped<IMechanicRepository, MechanicRepository>();
            builder.Services.AddScoped<IMechanicService, MechanicService>();

            builder.Services.AddScoped<IUserCommentsRepository, UserCommentsRepository>();
            builder.Services.AddScoped<IUserCommentsService, UserCommentsService>();

            builder.Services.AddScoped<ISubModelProblemRepository, SubModelProblemRepository>();
            builder.Services.AddScoped<ISubModelProblemService, SubModelProblemService>();

            builder.Services.AddScoped<ISubModelRepository, SubModelRepository>();
            builder.Services.AddScoped<ISubModelService, SubModelService>();

            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            builder.Services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            builder.Services.AddScoped<IChatService, ChatService>();
         
            builder.Services.AddScoped<IClientReviewRepository, ClientReviewRepository>();
            builder.Services.AddScoped<IClientReviewService, ClientReviewService>();


            builder.Services.AddSignalR();

            var app = builder.Build();

            app.MapHub<ChatHub>("/chatHub");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // 1. Əvvəlcə authentication
            app.UseAuthentication();

            // 2. Sonra authorization
            app.UseAuthorization();

       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");



                // Admin Area üçün
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                // Default route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}
