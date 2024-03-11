using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_P2.Models
{
    public class ParentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid ParentId { get; set; }
        [Required]
        public Guid StudentId { get; set; }

        //Foreign Keys
        [ForeignKey("ParentId")]
        public virtual Parents Parents { get; set; }

        [ForeignKey("StudentId")]
        public virtual Students Students { get; set; }

    }
}
