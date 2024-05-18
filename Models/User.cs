using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public List<Friendship> Friendships { get; set; } = new List<Friendship>();
        public List<UserChat> UserChats { get; set; } = new List<UserChat>();
    }
}
