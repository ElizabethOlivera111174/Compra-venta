
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Core.Entities
{
    public class Role 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
