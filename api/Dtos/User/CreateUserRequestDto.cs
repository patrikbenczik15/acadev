namespace api.Dtos.User
{
    public class CreateUserRequestDto
    {
        public string UserName { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;  // ! hashed password for user 
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    }
}