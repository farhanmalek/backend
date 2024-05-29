// Purpose: Contains the ChatHub class which is used to handle SignalR connections for the chat feature of the application.
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

        public async Task SendMessageByChatId(GetUserDto user, GetMessageDtoFromClient message, int chatId)
        {
            await _messageService.SaveMessage(chatId, user.UserId, message.Content!);
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessageByChatId", user, message);
        }
      
    }
}