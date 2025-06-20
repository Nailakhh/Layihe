using MercService.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Controllers
{
    public class ChatViewController : Controller
    {
        private readonly IMechanicService _mechanicService;

        public ChatViewController(IMechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }

        public async Task<IActionResult> Index(int mechanicId)
        {
            var mechanic = await _mechanicService.GetByIdAsync(mechanicId);
            if (mechanic == null)
                return NotFound();

            return View(mechanic); // View-a model kimi mexanik göndərilir
        }
    }
}