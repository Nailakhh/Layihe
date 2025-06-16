using MercService.Core.Entities;
using MercService.Core.Enums;
using MercService.Core.ViewModels;
using MercService.DAL.Context;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            // İstəsən istifadəçini qeydiyyatdan sonra avtomatik daxil et:


            // İstəsən rol da verə bilərsən:
            // await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            AppUser user;

            // Email yoxlamaq üçün '@' simvoluna baxırıq
            if (loginVM.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Belə istifadəçi mövcud deyil");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabınız müvəqqəti bloklanıb. Zəhmət olmasa sonra yenidən cəhd edin.");
                return View(loginVM);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email/İstifadəçi adı və ya şifrə yanlışdır");
                return View(loginVM);
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Logout


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/CreateRoles  (admin üçün bir dəfə çağırılır)
        [HttpGet]
        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                var roleName = role.ToString();
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            return RedirectToAction("Index", "Home");
        }


        //    [HttpGet]
        //    public IActionResult ForgotPassword()
        //    {
        //        return View();
        //    }

        //    // POST: ForgotPassword
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        //    {
        //        if (!ModelState.IsValid)
        //            return View(model);

        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
        //        {
        //            // Email yoxdursa, təhlükəsizlik baxımından yenə də success mesajı verilir
        //            return RedirectToAction("ForgotPasswordConfirmation");
        //        }

        //        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //        var callbackUrl = Url.Action("ResetPassword", "Account",
        //            new { token, email = user.Email }, protocol: Request.Scheme);

        //        // Burada email göndərmək hissəsini yazırsan
        //        await _emailSender.SendEmailAsync(
        //            user.Email,
        //            "Şifrəni sıfırla",
        //            $"Şifrənizi sıfırlamaq üçün <a href='{callbackUrl}'>buraya klikləyin</a>");

        //        return RedirectToAction("ForgotPasswordConfirmation");
        //    }

        //    // GET: ResetPassword
        //    [HttpGet]
        //    public IActionResult ResetPassword(string token, string email)
        //    {
        //        if (token == null || email == null)
        //            return RedirectToAction("Index", "Home");

        //        return View(new ResetPasswordVM { Token = token, Email = email });
        //    }

        //    // POST: ResetPassword
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        //    {
        //        if (!ModelState.IsValid)
        //            return View(model);

        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user == null)
        //            return RedirectToAction("ResetPasswordConfirmation");

        //        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        //        if (result.Succeeded)
        //            return RedirectToAction("ResetPasswordConfirmation");

        //        foreach (var error in result.Errors)
        //            ModelState.AddModelError(string.Empty, error.Description);

        //        return View(model);
        //    }
        //}
    }
}
