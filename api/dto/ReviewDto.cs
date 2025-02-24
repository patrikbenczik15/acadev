namespace api.dto
{
    public class Review
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int Rating { get; set; }

        public int ProfessorId { get; set; }

        public required Professor Professor { get; set; }  // ! Navigational property for professor

        public int UserId { get; set; }

        public required User User { get; set; }  //  ! Navigational property for user 

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

    }
}