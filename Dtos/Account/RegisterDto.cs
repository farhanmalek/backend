

using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? UserName {get;set;}

        [Required]
        [EmailAddress]
        public string? Email {get; set;}

        public string? Password {get;set;}
        
    }
}