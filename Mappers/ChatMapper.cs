using backend.Models;
using backend.Dtos.Chat;
using backend.Dtos.Account;
using backend.Dtos.Message;
using System.Linq;

namespace backend.Mappers
{
    public static class ChatMapper
    {
        public static GetChatDto MapToGetChatDto(this Chat chat)
        {
            return new GetChatDto
            {
                Id = chat.Id,
                Name = chat.Name,
                CreatedAt = chat.CreatedAt,
                Participants = chat.UserChats
                    .Where(uc => uc.User != null) // Ensure User is not null
                    .Select(uc => new GetUserDto
                    {
                        UserId = uc.User.Id,
                        UserName = uc.User.UserName,
                    }).ToList(),
                Messages = chat.Messages
                    .Select(m => new SendMessageDtoToClient
                    {
                        ChatId = m.ChatId,
                        SenderId = m.MessengerId,
                        Sender = new GetUserDto
                        {
                            UserId = m.MessengerId,
                            UserName = m.Messenger.UserName
                        },
                        Content = m.Content,
                        SentAt = m.SentAt
                    }).ToList()
            };
        }
    }
}
