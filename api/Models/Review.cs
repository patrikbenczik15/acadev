using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(3000)]
        public string Content { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public int? ProfessorId { get; set; }

        public required Professor? Professor { get; set; }  // ! Navigational property for professor

        [Required]
        public int? UserId { get; set; }

        public required User? User { get; set; }  //  ! Navigational property for user 

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

    }
}