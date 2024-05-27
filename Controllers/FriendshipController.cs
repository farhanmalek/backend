
using backend.Dtos.Account;
using backend.Extensions;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/friendships")]
    public class FriendshipController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IFriendshipService _friendshipRepo;

        public FriendshipController(UserManager<User> userManager, IFriendshipService friendshipRepo)
        {
            _userManager = userManager;
            _friendshipRepo = friendshipRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFriendsOfUser([FromQuery] string? searchInput)
        {
            var userName = User.GetUserName(); //use the claim to get signed in user's username
            var user = await _userManager.FindByNameAsync(userName);
            var friendsOfUser = await _friendshipRepo.GetFriends(user!);

            // Check if searchInput is not null or empty and perform a case-insensitive search
            if (!string.IsNullOrEmpty(searchInput))
            {
                var lowerCaseSearchInput = searchInput.ToLower(); // Convert search input to lowercase

                // Perform case-insensitive search by converting usernames to lowercase
                var searchedFriends = friendsOfUser.Where(u => u.UserName!.ToLower().Contains(lowerCaseSearchInput));
                var searchResponse = searchedFriends.Select(u => u.ToGetUserDto());
                return Ok(searchResponse);
            }

            var response = friendsOfUser.Select(u => u.ToGetUserDto());
            return Ok(response);
        }


        [HttpPost("send")]
        [Authorize]
        public async Task<IActionResult> SendFriendRequestToUser([FromBody] GetUserDto requestReceiver)
        {
            //get our signed in user
            var userName = User.GetUserName(); //use the claim to get signed in users user name
            var requestSender = await _userManager.FindByNameAsync(userName);

            var createdFriendship = await _friendshipRepo.SendFriendRequest(requestSender!, requestReceiver.ToUserFromGetUserDto());


            if (createdFriendship == null)
            {
                return BadRequest("Error sending friend request");
            }


            return Ok();

        }

        [HttpPut("status")]
        [Authorize]

        public async Task<IActionResult> HandleFriendRequestByUser([FromBody] GetUserDto requestSender, string action)
        {
            //Current person logged in will generally be accepting
            var userNameOfReceiver = User.GetUserName();
            var requestReceiver = await _userManager.FindByNameAsync(userNameOfReceiver);

            var updatedFriendShip = await _friendshipRepo.HandleFriendRequest(requestReceiver, requestSender.ToUserFromGetUserDto(), action);

            if (updatedFriendShip == null)
            {
                return NotFound("Friendship doesnt exist");
            }

            return Ok();

        }

        [HttpPost("status")]
        [Authorize]
        public async Task<IActionResult> getFriendshipStatus([FromBody] GetUserDto user2)
        {
            var loggedInUser = User.GetUserName();
            var loggedInUserUsername = await _userManager.FindByNameAsync(loggedInUser);

            var existingFriendship = await _friendshipRepo.GetFriendshipStatus(loggedInUserUsername!, user2.ToUserFromGetUserDto());

            if (existingFriendship == null)
            {
                return Ok("Friendship doesnt exist");
            }

            return Ok(existingFriendship.Status.ToString());
        }

        [HttpGet("requests")]
        [Authorize]
        public async Task<IActionResult> getFriendRequests()
        {
            var loggedInUser = User.GetUserName();
            var loggedInUserUsername = await _userManager.FindByNameAsync(loggedInUser);

            var friendRequests = await _friendshipRepo.GetFriendRequests(loggedInUserUsername!);

            if (friendRequests == null)
            {
                return Ok("No friend requests");
            }

            var response = friendRequests.Select(f => f.ToGetUserDto());

            return Ok(response);
        }





    }
}