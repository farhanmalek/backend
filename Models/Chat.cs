using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
 public class Chat
{
    public int Id { get; set; }
    public string? Name { get; set; } = "${User1Id} and ${User2Id}";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
 // Foreign keys
    public string User1Id { get; set; }
    public string User2Id { get; set; }

    public List<Message> Messages { get; set; } = new List<Message>();

   
}
}