using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;

        // Foreign Key
        [ForeignKey("Messenger")]
        public string MessengerId { get; set; }

        // Foreign Key
        [ForeignKey("Chat")]
        public int ChatId { get; set; }

        // Navigation Properties
        public virtual Chat Chat { get; set; }
        public virtual User Messenger { get; set; }
    }
}
