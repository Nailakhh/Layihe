using Microsoft.AspNetCore.SignalR;

namespace MercService.Hubs
{

    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var mechanicId = httpContext.Request.Query["mechanicId"];

            if (!string.IsNullOrEmpty(mechanicId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"Mechanic-{mechanicId}");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            var mechanicId = httpContext.Request.Query["mechanicId"];

            if (!string.IsNullOrEmpty(mechanicId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Mechanic-{mechanicId}");
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(int mechanicId, string userId, string message)
        {
            // Burada DB-ə yazmaq istəsən əlavə edə bilərsən

            await Clients.Group($"Mechanic-{mechanicId}")
                .SendAsync("ReceiveMessage", userId, message);
        }
    }
}