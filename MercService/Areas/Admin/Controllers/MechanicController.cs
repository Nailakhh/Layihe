using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercService.Business.Helpers;


namespace MercService.Areas.Admin.Controllers
{
    [Area("Admin")]


    public class MechanicController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public MechanicController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index(string? searchTerm)
        {
            var mechanics = await _context.Mechanics
                .Where(m => string.IsNullOrEmpty(searchTerm) || m.FullName.Contains(searchTerm))
                .ToListAsync();

            var vm = new MechanicVM
            {
                Mechanics = mechanics,
                SearchTerm = searchTerm
            };

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MechanicVM mechanicVM)
        {
            // MƏCBURİ FORMATLA
            mechanicVM.FullName = ToTitleCase(mechanicVM.FullName);
            mechanicVM.Designation = ToTitleCase(mechanicVM.Designation);

            if (!ModelState.IsValid)
                return View(mechanicVM);

            if (mechanicVM.File == null)
            {
                ModelState.AddModelError("File", "Şəkil yükləyin");
                return View(mechanicVM);
            }

            if (!mechanicVM.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "Yalnız şəkil faylı qəbul olunur");
                return View(mechanicVM);
            }

            if (mechanicVM.File.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("File", "Şəkil ölçüsü maksimum 2MB ola bilər");
                return View(mechanicVM);
            }

            var mechanic = new Mechanic
            {
                FullName = mechanicVM.FullName, // ARTIQ FORMATLANIB
                Designation = mechanicVM.Designation,
                FacebookUrl = mechanicVM.FacebookUrl,
                TwitterUrl = mechanicVM.TwitterUrl,
                InstagramUrl = mechanicVM.InstagramUrl,
                ExperienceYear = mechanicVM.ExperienceYear,
                ImageUrl = mechanicVM.File.UploadFile(_environment.WebRootPath, "upload/mechanic")
            };

            await _context.Mechanics.AddAsync(mechanic);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null) return NotFound();

            var mechanicVM = new MechanicVM
            {
                FullName = mechanic.FullName,
                Designation = mechanic.Designation,
                FacebookUrl = mechanic.FacebookUrl,
                TwitterUrl = mechanic.TwitterUrl,
                InstagramUrl = mechanic.InstagramUrl,
                 ExistingImageUrl = mechanic.ImageUrl,
                   ExperienceYear = mechanic.ExperienceYear,
                Id = mechanic.Id
            };

            return View(mechanicVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, MechanicVM mechanicVM)
        {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null) return NotFound();

            // ModelState yoxlaması sadəcə FullName, Designation və digər sadə validasiyalar üçündür
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                // Səhvləri yadda saxlayın, məsələn TempData-ya
                TempData["Errors"] = string.Join("; ", errors);
                return View(mechanicVM);
            }

            // Yeni şəkil varsa yoxlayırıq və dəyişirik
            if (mechanicVM.File != null)
            {
                if (!mechanicVM.File.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("File", "Yalnız şəkil faylı qəbul olunur");
                    return View(mechanicVM);
                }

                if (mechanicVM.File.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("File", "Şəkil ölçüsü maksimum 2MB ola bilər");
                    return View(mechanicVM);
                }

                // Köhnə şəkli sil və yenisini yüklə
                if (!string.IsNullOrEmpty(mechanic.ImageUrl))
                {
                    mechanic.ImageUrl.DeleteFile(_environment.WebRootPath, "upload/mechanic");
                }

                mechanic.ImageUrl = mechanicVM.File.UploadFile(_environment.WebRootPath, "upload/mechanic");
            }

            // Şəxsi məlumatları yenilə
            mechanic.FullName = ToTitleCase(mechanicVM.FullName);
            mechanic.Designation = ToTitleCase(mechanicVM.Designation);
            mechanic.FacebookUrl = mechanicVM.FacebookUrl;
            mechanic.TwitterUrl = mechanicVM.TwitterUrl;
            mechanic.InstagramUrl = mechanicVM.InstagramUrl;
            mechanic.ExperienceYear = mechanicVM.ExperienceYear;



            _context.Mechanics.Update(mechanic);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Mütəxəssis uğurla yeniləndi";
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null) return NotFound();

            if (!string.IsNullOrEmpty(mechanic.ImageUrl))
            {
                mechanic.ImageUrl.DeleteFile(_environment.WebRootPath, "upload/mechanic");
            }

            _context.Mechanics.Remove(mechanic);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ✨ Bu metod yazının ilk hərfini böyük edir
        private string ToTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            var delimiters = new[] { ' ', '-', '\'' };
            var chars = input.Trim().ToLower().ToCharArray();

            bool capitalizeNext = true;

            for (int i = 0; i < chars.Length; i++)
            {
                if (capitalizeNext && char.IsLetter(chars[i]))
                {
                    chars[i] = char.ToUpper(chars[i]);
                    capitalizeNext = false;
                }
                else if (delimiters.Contains(chars[i]))
                {
                    capitalizeNext = true;
                }
            }

            return new string(chars);
        }
    }
}