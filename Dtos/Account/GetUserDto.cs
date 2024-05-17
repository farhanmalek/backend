using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Account
{
    //The response sent back to the client (User Info)
    public class GetUserDto
    {
        
        public string? UserId { get; set; }
        public string? UserName {get; set;}
        public string? Email {get;set;}
        
    }
}