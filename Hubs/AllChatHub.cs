using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Message;
using backend.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
    public class AllChatHub : Hub
    {
        public AllChatHub()
        {
      
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "ChatCards");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "ChatCards");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task NotifyLastMessageUpdated(int chatId, GetMessageDtoFromClient message)
        {
            await Clients.Group("ChatCards").SendAsync("ReceiveLastMessageUpdate", chatId, message);
        }
    }
}
