namespace JWT_P2.DTOs.ParentDetails
{
    public class ParentDetailsPutDTO
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Guid StudentId { get; set; }
    }
}
