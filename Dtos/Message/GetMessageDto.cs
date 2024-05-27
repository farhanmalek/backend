

using backend.Dtos.Account;

namespace backend.Dtos.Message
{
    //The form that the message will received from the client
    public class GetMessageDtoFromClient
    {
        public int ChatId { get; set; }
        public string SenderId { get; set; }
        public GetUserDto Sender { get; set; }
        public string Content { get; set; }
        
    }
}