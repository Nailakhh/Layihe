using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MercService.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }
            



        [HttpGet]
        public IActionResult Index()
        {
            var vm = new SearchViewModel
            {
                Categories = _context.Categories.ToList(),
                Models = new List<Model>(),
                Problems = _context.CarProblems.ToList(),
                Mechanics = new List<Mechanic>(),
                Comments = new List<UserComments>(),
                Years = Enumerable.Range(2000, DateTime.Now.Year - 1999)
                         .Select(y => new SelectListItem
                         {
                             Value = y.ToString(),
                             Text = y.ToString()
                         }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel vm)
        {
            var modelProblem = _context.SubModelProblems
                .Include(mp => mp.Mechanics)
                .Include(mp => mp.Comments)
                .FirstOrDefault(mp =>
                    mp.SubModelId == vm.SelectedModelId &&
                    mp.CarProblemId == vm.SelectedProblemId);

            if (modelProblem != null)
            {
                vm.Mechanics = modelProblem.Mechanics.ToList();
                vm.Comments = modelProblem.Comments.ToList();
            }
            else
            {
                vm.Mechanics = new List<Mechanic>();
                vm.Comments = new List<UserComments>();
            }

            // seçimləri doldur ki, səhifədə yenidən göstərilsin
            vm.Categories = _context.Categories.ToList();
            vm.Models = _context.Models
                .Where(m => m.CategoryId == vm.SelectedCategoryId).ToList();
            vm.Problems = _context.CarProblems.ToList();

            vm.Years = Enumerable.Range(2000, DateTime.Now.Year - 1999)
                                 .Select(y => new SelectListItem
                                 {
                                     Value = y.ToString(),
                                     Text = y.ToString()
                                 }).ToList();

            return View(vm);
        }

    }
}
