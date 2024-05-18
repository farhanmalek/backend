using backend.Models;
using backend.Dtos.Chat;
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
                Participants = chat.UserChats.Select(uc => uc.User).ToList(),
                Messages = chat.Messages // Assuming you have a direct mapping from Message entity to Message in the DTO
            };
        }
    }
}
