using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<UserChat> UserChats { get; set; } = new List<UserChat>();

        public List<Message> Messages { get; set; } = new List<Message>();

    }
}
