
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
    [Route("api/chats")]
    public class ChatController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IChatService _chatRepo;
        private readonly IMessageService _messageRepo;
        public ChatController(UserManager<User> userManager, IChatService chatRepo, IMessageService messageRepo)

        {
            _chatRepo = chatRepo;
            _userManager = userManager;
            _messageRepo = messageRepo;

        }

        //Get chats for a logged in user
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetChatsOfUser() 
        {
            var userName = User.GetUserName(); //use the claim to get signed in users user name
            var user = await _userManager.FindByNameAsync(userName);
            var userChats = await _chatRepo.GetChats(user!);

            var userChatsResponse = userChats.Select(chats => chats.MapToGetChatDto());

            return Ok(userChatsResponse);
        }

        //get chats by id
        [HttpGet("{id:int}")]
        [Authorize]

        public async Task<IActionResult> GetChatById(int id)
        {
            var chatById = await _chatRepo.GetChatById(id);

            if (chatById == null)
            {
                return NotFound("Chat not found");
            }

            return Ok(chatById.MapToGetChatDto());
        }

        //create a new chat
        [HttpPost("create")]
        [Authorize]

        public async Task<IActionResult> CreateNewChat([FromBody] List<GetUserDto> chatParticipants)
        {

            var participants = chatParticipants.Select(cp => cp.ToUserFromGetUserDto()).ToList();
            var chatCreator = User.GetUserName();
            var newChatCreator = await _userManager.FindByNameAsync(chatCreator);
            participants.Add(newChatCreator!);
            //send to the repo
            var newChat = await _chatRepo.CreateChat(participants);

            if (newChat == null)
            {
                return BadRequest("Error creating new chat");
            }

            return Ok(newChat.MapToGetChatDto());
        }

//edit chatname by id
        [HttpPut("{id:int}")]
        [Authorize]

        public async Task<IActionResult> EditChatNameById([FromRoute]int id,[FromQuery] string newChatName)
        {
            System.Console.WriteLine(newChatName);
            var editedChat = await _chatRepo.EditChatName(newChatName, id);

            if (editedChat == null)
            {
                return BadRequest("Error Updating Chat Name");
            }

            return Ok(editedChat.MapToGetChatDto());

        }

//get all messages in a chat by its id

        [HttpGet("{id:int}/messages")]
        [Authorize]

        public async Task<IActionResult> GetMessagesByChatId([FromRoute] int id)
        {
            var messages = await _messageRepo.GetMessages(id);

            if (messages == null)
            {
                return Ok("No messages found");
            }

            var formattedMessages = messages.Select(m => m.MapToSendMessageDto());

            return Ok(formattedMessages);
        }
        
    }
}