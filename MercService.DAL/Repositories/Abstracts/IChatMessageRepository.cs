using MercService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.DAL.Repositories.Abstracts
{
    public interface IChatMessageRepository
    {
        Task<List<ChatMessage>> GetMessagesForMechanicAsync(int mechanicId, int lastMessageId = 0);
        Task AddMessageAsync(ChatMessage message);
    }

}
