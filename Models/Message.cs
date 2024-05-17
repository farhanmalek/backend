

using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        //Foreign Key
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
      
        //Foreign Key
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
      

        //Foreign Key
        [ForeignKey("Chat")]
        public int ChatId { get; set; }
        //Navigation Property
        public Chat? Chat { get; set; }
        
    }
}