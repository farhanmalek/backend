using backend.Models;
using backend.Dtos.Chat;
using System.Linq;
using backend.Dtos.Account;

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
                Messages = chat.Messages // Assuming you have a direct mapping from Message entity to Message in the DTO
            };
        }
    }
}
