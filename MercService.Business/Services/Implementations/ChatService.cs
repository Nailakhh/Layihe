using MercService.Business.Services.Interfaces;
using MercService.Core.Models;
using MercService.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IChatMessageRepository _chatRepo;

        public ChatService(IChatMessageRepository chatRepo)
        {
            _chatRepo = chatRepo;
        }

        public async Task<List<ChatMessage>> GetChatMessagesAsync(int mechanicId, int lastMessageId = 0)
        {
            return await _chatRepo.GetMessagesForMechanicAsync(mechanicId, lastMessageId);
        }

        public async Task AddChatMessageAsync(int mechanicId, string senderId, string text)
        {
            var message = new ChatMessage
            {
                MechanicId = mechanicId,
                SenderId = senderId,
                Text = text,
                SentAt = DateTime.UtcNow
            };

            await _chatRepo.AddMessageAsync(message);
        }
    }

}
