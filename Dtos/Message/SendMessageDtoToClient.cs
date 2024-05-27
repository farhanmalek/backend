using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Account;

namespace backend.Dtos.Message
{
    //The form that the message will returned to the client
    public class SendMessageDtoToClient
    {
        public int ChatId { get; set; }
        public string SenderId { get; set; }
        public GetUserDto Sender { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        
    }
}