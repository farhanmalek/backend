
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
        public async Task<IActionResult> GetFriendsOfUser([FromQuery] string? searchInput = null)
        {
            var userName = User.GetUserName(); //use the claim to get signed in users user name
            var user = await _userManager.FindByNameAsync(userName);
            var friendsOfUser = await _friendshipRepo.GetFriends(user!);
            //so now I have a list of users that are friends of the user
            if (!string.IsNullOrEmpty(searchInput)) {
                //if there is no search input, return all friends
                var searchedFriend = friendsOfUser.Where(u => u.UserName.Contains(searchInput));
                var searchResponse = searchedFriend.Select(u => u.ToGetUserDto());
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
                return BadRequest("Friendship doesnt exist");
            } 

            return Ok();

        }


        
       
        
    }
}