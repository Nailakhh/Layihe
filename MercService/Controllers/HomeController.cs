using MercService.Core.ViewModels;
using MercService.DAL.Context;
using MercService.Models;
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

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Categories = await _context.Categories.ToListAsync(),
                Models = await _context.Models.ToListAsync(),
                Problems = await _context.CarProblems.ToListAsync(),
                Mechanics = await _context.Mechanics.ToListAsync(),
                Years = Enumerable.Range(2000, DateTime.Now.Year - 1999)
        .Select(y => new SelectListItem
        {
            Value = y.ToString(),
            Text = y.ToString()
        }).ToList()
            };

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
