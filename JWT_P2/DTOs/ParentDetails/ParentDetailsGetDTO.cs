using System.ComponentModel.DataAnnotations;

namespace JWT_P2.DTOs.ParentDetails
{
    public class ParentDetailsGetDTO
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Guid StudentId { get; set; }
    }
}
