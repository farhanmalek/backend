

using backend.Dtos.Account;
using backend.Dtos.Message;
using backend.Models;

namespace backend.Mappers
{
    public static class MessagesMapper
    {
        public static GetMessageDtoFromClient MapToGetMessageDto(this Message message)
        {
            return new GetMessageDtoFromClient
            {
                ChatId = message.ChatId,
                Sender = new GetUserDto {
                    UserId = message.Messenger.Id,
                    UserName = message.Messenger.UserName
                },
                Content = message.Content,
            };
         
        }

        public static SendMessageDtoToClient MapToSendMessageDto(this Message message)
        {
            return new SendMessageDtoToClient
            {
                ChatId = message.ChatId,
                Sender = new GetUserDto {
                    UserId = message.MessengerId,
                    UserName = message.Messenger.UserName
                },
                Content = message.Content,
                SentAt = message.SentAt
            };
        }
        
    }
}