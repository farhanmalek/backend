using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class FriendshipRepository : IFriendshipService
    {
        //DI the database
        private readonly ApplicationDBContext _context;
        public FriendshipRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Friendship> SendFriendRequest(User user1, User user2)
        {
            try
            {
                //Add here a check that the friendship already exists and then in that case, just change the status to pending and then exist out the function.
                var existingFriendship = _context.Friendships.FirstOrDefault(f =>
                        (f.User1Id == user1.Id && f.User2Id == user2.Id) ||
                        (f.User1Id == user2.Id && f.User2Id == user1.Id));

                if (existingFriendship != null)
                {
                    existingFriendship.Status = FriendshipStatus.Pending;
                    await _context.SaveChangesAsync(); // Save changes to the database
                    return existingFriendship;
                }

                var friendship = new Friendship()
                {
                    User1Id = user1.Id,
                    User2Id = user2.Id,
                    Status = FriendshipStatus.Pending
                };

                _context.Friendships.Add(friendship);
                await _context.SaveChangesAsync();

                return friendship;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending a friend request: {ex.Message}");
                throw;
            }
        }




        public async Task<List<User>> GetFriends(User user)
        {
            var userId = user.Id;

            // Query the database for friendships where the user is either User1 or User2
            var friendships = await _context.Friendships
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .Include(f => f.User1) // Eagerly load User1
                .Include(f => f.User2) // Eagerly load User2
                .ToListAsync();

            // Project the friendships into a list of User objects representing the friends
            var friends = friendships
                .Select(f => f.User1Id == userId ? f.User2 : f.User1)
                .ToList();

            return friends;
        }

        public async Task<Friendship>? HandleFriendRequest(User user1, User user2, string action)
        {
            try
            {
                // Validate the action parameter
                if (action != "accept" && action != "decline")
                {
                    throw new ArgumentException("Invalid action. Please provide 'accept' or 'decline'.", nameof(action));
                }

                // Check if the friendship exists
                var existingFriendship = _context.Friendships.FirstOrDefault(f =>
                    (f.User1Id == user1.Id && f.User2Id == user2.Id) ||
                    (f.User1Id == user2.Id && f.User2Id == user1.Id));

                // Friendship doesn't exist
                if (existingFriendship == null)
                {
                    return null;
                }

                // Update friendship status based on the action
                if (action == "accept")
                {
                    existingFriendship.Status = FriendshipStatus.Accepted;
                }
                else if (action == "decline")
                {
                    existingFriendship.Status = FriendshipStatus.Rejected;
                }

                // Save changes to the database
                await _context.SaveChangesAsync();

                return existingFriendship;
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}