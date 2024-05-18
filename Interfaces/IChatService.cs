
using backend.Models;

namespace backend.Interfaces
{
    public interface IChatService
    {
        //get all chat rooms for a given user.
        Task<List<Chat>> GetChats(User user);

        //get a certain chatroom based on its id
        Task<Chat?> GetChatById(int chatId);

        //create a new chatroom 
        Task<Chat> CreateChat(List<User> participants);

        Task<Chat> EditChatName(string chatName, int chatId);

        
    }
}