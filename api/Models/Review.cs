using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace api.models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Range(1, 5)]  // Rating între 1 și 5
        public int Rating { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        public required Professor Professor { get; set; }  // ! Navigational property for professor

        [Required]
        public int UserId { get; set; }

        public required User User { get; set; }  //  ! Navigational property for user 

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

    }
}