namespace JWT_P2.DTOs.Messages
{
    public class MessagesPostDTO
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? SchoolId { get; set; }
    }
}
