

using backend.Models;

namespace backend.Interfaces
{
    public interface IMessageService
    {
        Task SaveMessage(int chatId, string senderId, string content);
        Task<List<Message>> GetMessages(int chatId);
    }
}