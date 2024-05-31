using backend.Dtos.Account;
using backend.Dtos.Message;
using backend.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        
        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public override async Task OnConnectedAsync()
        {
            // Assuming the chatId is passed as a query string parameter
            var chatId = Context.GetHttpContext().Request.Query["chatId"];
            if (!string.IsNullOrEmpty(chatId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
                await base.OnConnectedAsync();
            }
        }

        public async Task SendMessageByChatId(GetUserDto user, GetMessageDtoFromClient message, int chatId)
        {
            await _messageService.SaveMessage(chatId, user.UserId, message.Content!);
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessageByChatId", user, message);
        }
    }
}
