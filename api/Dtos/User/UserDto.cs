namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;  // ! hashed password for user 

        //public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    }
}