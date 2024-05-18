
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ChatRepository : IChatService
    {
        private readonly ApplicationDBContext _context;
        public ChatRepository(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<Chat> CreateChat(List<User> participants)
        {
            // Create a new chat
            var chat = new Chat
            {
                CreatedAt = DateTime.Now
            };

            // Add the chat to the context
            _context.Chats.Add(chat);

            // Save changes to create UserChat records in the database
            await _context.SaveChangesAsync();

            return chat;
        }

        //change name of chat 
        public async Task<Chat> EditChatName(string chatName, int chatId)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(chatName) || chatId <= 0)
            {
                throw new ArgumentException("Invalid input parameters");
            }

            // Find the chat by its ID
            var chat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == chatId);

            if (chat == null)
            {
                throw new ArgumentException("Chat not found");
            }

            // Update the chat name
            chat.Name = chatName;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle database save errors
                throw new Exception("Error while saving changes to the database", ex);
            }

            // Return the updated chat
            return chat;
        }


        //get chat by id, ie when i click on a chat it will pop up in the component
        public async Task<Chat?> GetChatById(int chatId)
        {
            var singleChat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == chatId);
            return singleChat;
        }

        //Get all chats for a logged in geeza
        public async Task<List<Chat>> GetChats(User user)
        {
            var chats = await _context.UserChats
                .Where(uc => uc.UserId == user.Id)
                .Select(uc => uc.Chat)
                .ToListAsync();

            return chats;
        }
    }
}