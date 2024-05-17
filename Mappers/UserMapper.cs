
using backend.Dtos.Account;
using backend.Models;

namespace backend.Mappers
{
    public static class UserMapper
    {
        //Map User Model to GetUserDto
        public static GetUserDto ToGetUserDto (this User userModel)
        {
            return new GetUserDto {
                UserId = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email
            };
        }

        public static User ToUserFromGetUserDto (this GetUserDto userDto)
        {
            return new User {
                Id = userDto.UserId!,
                UserName = userDto.UserName,
                Email = userDto.Email
            };
        }
    }
}