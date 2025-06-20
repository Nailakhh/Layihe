using MercService.Business.Services.Implementations;
using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MercService.Controllers
{
    public class MechanicController : Controller
    {
        private readonly IMechanicService _mechanicService;
        private readonly ICommentService _commentService;

        public MechanicController(IMechanicService mechanicService, ICommentService commentService)
        {
            _mechanicService = mechanicService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(string? searchTerm)
        {
            var mechanics = await _mechanicService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                mechanics = mechanics.Where(m =>
                    m.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    m.Designation.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            var viewModel = new MechanicVM
            {
                Mechanics = mechanics.ToList(),
                SearchTerm = searchTerm
            };


            //var layoutVM = new HomeIndexViewModel
            //{
            //    ContactInfo = await _mechanicService.GetContactInfoAsync(),
            //    Locations = await _mechanicService.GetLocationsAsync(),
            //    SocialLinks = await _mechanicService.GetSocialLinksAsync()
            //};
            //ViewData["LayoutData"] = layoutVM;

            return View(viewModel);
        }

        public async Task<IActionResult> Search(string? searchTerm)
        {
            var mechanics = await _mechanicService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                mechanics = mechanics.Where(m =>
                    m.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    m.Designation.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            return PartialView("_MechanicsListPartial", mechanics.ToList());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var mechanic = await _mechanicService.GetByIdAsync(id);
            if (mechanic == null)
                return NotFound();

            var similarMechanics = await _mechanicService.GetSimilarMechanicsAsync(id);

            // İstifadəçi ID-sini tap
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            // İndi userId ilə şərhləri götürürük ki, "IsLikedByCurrentUser" dəyəri düzgün olsun
            var comments = await _commentService.GetCommentsWithUserByMechanicIdAsync(id, userId);

            var model = new MechanicDetailVM
            {
                Mechanic = mechanic,
                SimilarMechanics = similarMechanics,
                Comments = comments,
                IsFavoritedByUser = false,  // lazım olsa təyin et
                NewCommentText = null,
                NewComment = null
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(int mechanicId, string text, int rating)
        {
            if (string.IsNullOrWhiteSpace(text) || rating < 1 || rating > 5)
            {
                TempData["ErrorMessage"] = "Zəhmət olmasa, düzgün rəy və qiymətləndirmə daxil edin.";
                return RedirectToAction("Detail", new { id = mechanicId });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var comment = new UserComments
            {
                MechanicId = mechanicId,
                AppUserId = userId,
                Text = text,
                Rating = rating,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _commentService.AddCommentAsync(comment);

            if (!result)
            {
                TempData["ErrorMessage"] = "Şərhinizdə qadağan olunmuş ifadələr var. Zəhmət olmasa, şərhinizi dəyişdirin.";
            }

            return Redirect($"{Url.Action("Detail", new { id = mechanicId })}#comments");

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LikeComment(int commentId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Json(new { success = false, message = "İstifadəçi daxil olmayıb." });

            var liked = await _commentService.ToggleLikeAsync(commentId, userId);
            var likeCount = await _commentService.GetLikeCountAsync(commentId);

            return Json(new { success = true, liked = liked, likeCount = likeCount });
        }
    }
}