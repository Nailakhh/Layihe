using MercService.Core.Entities;
using MercService.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, IWebHostEnvironment env, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _env = env;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            var vm = new ProfileEditVM
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Bio = user.Bio,
                Address = user.Address,
                BirthDate = user.BirthDate,
                ExistingAvatarUrl = user.AvatarUrl
            };
            ViewData["UserName"] = user.UserName;


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileEditVM vm)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View(vm);

            // İstifadəçi adını dəyişməyə cəhd varsa və fərqlidirsə
            if (user.UserName != vm.UserName)
            {
                var lastModified = user.RegisteredAt;

                if ((DateTime.UtcNow - lastModified).TotalDays < 30)
                {
                    ModelState.AddModelError("", "İstifadəçi adını dəyişmək üçün 30 gün gözləməlisiniz.");
                    return View(vm);
                }

                var usernameChangeResult = await _userManager.SetUserNameAsync(user, vm.UserName);
                if (!usernameChangeResult.Succeeded)
                {
                    foreach (var error in usernameChangeResult.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View(vm);
                }
            }

            // Digər sahələr
            user.Name = vm.Name;
            user.Surname = vm.Surname;
            user.Bio = vm.Bio;
            user.Address = vm.Address;
            user.BirthDate = vm.BirthDate;

            // Şəkil varsa yüklə
            if (vm.Avatar != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(vm.Avatar.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "upload/profilimage", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await vm.Avatar.CopyToAsync(stream);
                }

                user.AvatarUrl = fileName;
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(vm);
            }

            // Dəyişikliklərdən sonra sessiyanı yenilə
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Edit");
        }




        [HttpPost]
        public async Task<IActionResult> DeleteAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            if (!string.IsNullOrEmpty(user.AvatarUrl))
            {
                var filePath = Path.Combine(_env.WebRootPath, "upload/profilimage", user.AvatarUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                user.AvatarUrl = null;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction("Edit");
        }


    }

}