using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Account;
using backend.Dtos.Message;
using backend.Models;

namespace backend.Dtos.Chat
{
    public class GetChatDto
    {
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    // public DateTime CreatedAt { get; set; } = DateTime.Now;
    // Foreign keys
    public List<GetUserDto> Participants { get; set; }
    public List<SendMessageDtoToClient> Messages { get; set; }
    }
}