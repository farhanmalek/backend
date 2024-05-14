// Purpose: DTO for creating a new user.

namespace backend.Dtos.Account
{
    public class NewUserDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }

    }
}