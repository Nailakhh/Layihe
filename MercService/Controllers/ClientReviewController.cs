using MercService.Business.Services.Interfaces;
using MercService.Core.Entities;
using MercService.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Controllers
{

    public class ClientReviewController : Controller
    {
        private readonly IClientReviewService _reviewService;
        private readonly UserManager<AppUser> _userManager;

        public ClientReviewController(IClientReviewService reviewService, UserManager<AppUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }

        // Təsdiq edilmiş rəyləri göstər (frontend üçün)
        public async Task<IActionResult> Index()
        {
            var reviews = await _reviewService.GetAllApprovedAsync();
            return View(reviews);
        }






        // Rəy əlavə etmək üçün GET
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ClientReview review)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Formda səhv var.";
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            review.Name = !string.IsNullOrEmpty(user.FullName) ? user.FullName : user.UserName;
            review.ImageUrl = string.IsNullOrEmpty(user.AvatarUrl)
                ? Url.Content("~/assets/img/defuserprofil.png")
                : user.AvatarUrl;

            review.AppUserId = user.Id;

            review.IsApproved = false;
            review.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _reviewService.AddReviewAsync(review);

            TempData["SuccessMessage"] = "Rəyiniz uğurla göndərildi. Təşəkkürlər!";
            return RedirectToAction("Index", "Home");
        }



    }
}