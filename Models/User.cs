
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public List<Friendship> Friendships { get; set; } = new List<Friendship>();
        public List<Chat> Chats { get; set; } = new List<Chat>();

        
    }
}