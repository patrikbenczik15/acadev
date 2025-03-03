using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string University { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Department { get; set; } = string.Empty;

        // ! review list for professor
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}