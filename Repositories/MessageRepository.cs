
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class MessageRepository : IMessageService
    {
        private readonly ApplicationDBContext _context;
        public MessageRepository(ApplicationDBContext context)
        {
            _context = context;
            
        }
        //Get all the messages from a chat
        public async Task<List<Message>> GetMessages(int chatId)
        {
            return await _context.Messages.Include(m => m.Messenger).Where(m => m.ChatId == chatId).ToListAsync();
        }

        //save a message to the database
        public Task SaveMessage(int chatId, string senderId, string content)
        {
            var message = new Message
            {
                ChatId = chatId,
                MessengerId = senderId,
                Content = content,
                SentAt = DateTime.Now
            };
            _context.Messages.Add(message);
            return _context.SaveChangesAsync();
        }
    }
}