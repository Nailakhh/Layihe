using MercService.Business.Services.Implementations;
using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MercService.Controllers
{
    
    public class  MechanicController: Controller
    {
        private readonly IMechanicService _mechanicService;
        private readonly ICommentService _commentService;

        public MechanicController(IMechanicService mechanicService, ICommentService commentService)
        {
            _mechanicService = mechanicService;
            _commentService = commentService;
        }


        // Bütün mütəxəssisləri göstərən əsas səhifə
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

            return View(viewModel);
        }

        // AJAX üçün partial render edən action
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
            var comments = await _commentService.GetCommentsByMechanicIdAsync(id);

            var model = new MechanicDetailVM
            {
                Mechanic = mechanic,
             
                SimilarMechanics = similarMechanics,
                Comments = comments,
                IsFavoritedByUser = false,  // Bu məlumatı özünüz istifadəçiyə görə təyin edin
                NewCommentText = null,
                NewComment = null
            };

            return View(model);
        }

        [HttpPost]
      
        public async Task<IActionResult> LikeComment(int commentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var result = await _commentService.ToggleLikeAsync(commentId, userId);
            if (!result)
                return BadRequest("Like toggle failed.");

            var likeCount = await _commentService.GetLikeCountAsync(commentId);
            return Json(new { likeCount });
        }

    }
}