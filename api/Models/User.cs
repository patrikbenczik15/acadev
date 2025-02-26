using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(256)] // Adjust the maximum length based on the hash algorithm
        public string PasswordHash { get; set; } = string.Empty;  // ! hashed password for user 

        [Required]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
        public ICollection<Review> Reviews { get; set; } = new List<Review>(); // ! Review list for user
    }
}