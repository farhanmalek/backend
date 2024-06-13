
using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
    public class CreatedChatsHub : Hub
    {
    
        
        public override async Task OnConnectedAsync()
        {
            var userId = Context.GetHttpContext()!.Request.Query["userId"];
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userId!);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.GetHttpContext()!.Request.Query["userId"];
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId!);
            }
            await base.OnDisconnectedAsync(exception);
        }


        
    }
}