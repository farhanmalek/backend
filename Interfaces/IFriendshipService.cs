using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces
{
    public interface IFriendshipService
    {
        Task<List<User>> GetFriends(User user);
        Task<Friendship> SendFriendRequest(User user1, User user2);
        Task<Friendship>? HandleFriendRequest(User user1, User user2,string action);
        Task<Friendship?> GetFriendshipStatus(User user1, User user2);
        Task<List<User>> GetFriendRequests(User user);

    }
}