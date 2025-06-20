using MercService.Business.Services.Implementations;
using MercService.Business.Services.Interfaces;
using MercService.Core.Entities;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly UserManager<AppUser> _userManager; 



        public ChatController(IChatService chatService, UserManager<AppUser> userManager)
        {
            _chatService = chatService;
            _userManager = userManager;
        }

        [HttpGet("{mechanicId}")]
        public async Task<IActionResult> GetMessages(int mechanicId, int lastMessageId = 0)
        {
            var messages = await _chatService.GetChatMessagesAsync(mechanicId, lastMessageId);
            return Ok(messages);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _chatService.AddChatMessageAsync(dto.MechanicId, userId, dto.Text);
            return Ok(new { success = true });
        }

    }

    public class SendMessageDto
    {
        public int MechanicId { get; set; }
        public string Text { get; set; }
    }
}