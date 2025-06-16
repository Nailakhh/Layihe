using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Controllers
{
    public class CarProblemController : Controller
    {
        private readonly ICarProblemService _carProblemService;

        public CarProblemController(ICarProblemService carProblemService)
        {
            _carProblemService = carProblemService;
        }

        public async Task<IActionResult> Index()
        {
            var problems = await _carProblemService.GetAllProblemsAsync();
            return View(problems);
        }

        public async Task<IActionResult> Details(int id)
        {
            var problem = await _carProblemService.GetByIdAsync(id);
            if (problem == null)
                return NotFound();

            return View(problem);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarProblem carProblem)
        {
            if (!ModelState.IsValid)
                return View(carProblem);

            await _carProblemService.AddAsync(carProblem);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var problem = await _carProblemService.GetByIdAsync(id);
            if (problem == null)
                return NotFound();

            return View(problem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarProblem carProblem)
        {
            if (!ModelState.IsValid)
                return View(carProblem);

            await _carProblemService.UpdateAsync(carProblem);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _carProblemService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
