using api.Dtos.User;
using api.Models;
using Azure.Identity;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email
            };
        }
    }
}