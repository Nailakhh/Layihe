using MercService.Business.Services.Implementations;
using MercService.Business.Services.Interfaces;
using MercService.Core.Entities;
using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Context;
using MercService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MercService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IClientReviewService _clientReviewService;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(ILogger<HomeController> logger, AppDbContext context,IClientReviewService clientReviewService, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _context = context;
            _clientReviewService = clientReviewService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var reviews = await _clientReviewService.GetAllApprovedAsync();

            var user = await _userManager.GetUserAsync(User);
            string loggedInUserName = user != null ? (user.FullName ?? user.UserName) : "";
            string loggedInUserAvatar = user?.AvatarUrl ?? Url.Content("~/assets/img/defuserprofil.png");

            var viewModel = new HomeIndexViewModel
            {
                Location = await _context.Locations.FirstOrDefaultAsync(),
                ContactInfo = await _context.ContactInfos.FirstOrDefaultAsync(),
                SocialLinks = await _context.SocialLinks.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                Models = await _context.Models.ToListAsync(),
                ClientReviews = reviews,
                Problems = await _context.CarProblems.ToListAsync(),
                Mechanics = await _context.Mechanics.ToListAsync(),
                Locations = await _context.Locations.ToListAsync(),
                ChatMechanics = await _context.Mechanics.Select(m => new MechanicVM
                {
                    Id = m.Id,
                    FullName = m.FullName,
                    ExistingImageUrl = m.ImageUrl
                }).ToListAsync(),
                Years = Enumerable.Range(2000, DateTime.Now.Year - 1999)
                    .Select(y => new SelectListItem
                    {
                        Value = y.ToString(),
                        Text = y.ToString()
                    }).ToList(),
                MastersList = await _context.Mechanics
                    .Select(m => "Usta " + m.FullName)
                    .ToListAsync(),
                LoggedInUserName = loggedInUserName,
                LoggedInUserAvatar = loggedInUserAvatar
            };

            ViewData["LayoutData"] = viewModel;

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
