using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_P2.Models
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Year { get; set; }
        public char Group { get; set; }
        public Guid SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public virtual Schools Schools { get; set; }


    }
}
