using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_P2.Models
{
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Body { get; set; }
        public Guid StudentId { get; set; }
        public Guid SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual Schools Schools { get; set; }
        [ForeignKey("StudentId")]
        public virtual Students Students { get; set; }
    }
}
