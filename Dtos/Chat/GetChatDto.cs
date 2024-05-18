using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Dtos.Chat
{
    public class GetChatDto
    {
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // Foreign keys
    public List<User> Participants { get; set; }

    public List<Message> Messages { get; set; } = new List<Message>();
    }
}