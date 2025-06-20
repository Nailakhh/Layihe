using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Services.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatMessage>> GetChatMessagesAsync(int mechanicId, int lastMessageId = 0);
        Task AddChatMessageAsync(int mechanicId, string senderId, string text);
    }
}
