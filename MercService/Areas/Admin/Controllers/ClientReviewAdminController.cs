using MercService.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class ClientReviewAdminController : Controller
    {
        private readonly IClientReviewService _reviewService;

        public ClientReviewAdminController(IClientReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // Bütün rəylər (təsdiq edilmiş və edilməmiş)
        public async Task<IActionResult> Index()
        {
            var reviews = await _reviewService.GetAllAsync(); // bütün rəylər
            return View(reviews);
        }

        // Rəyi təsdiqlə
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            await _reviewService.ApproveReviewAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Rəyi sil
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
