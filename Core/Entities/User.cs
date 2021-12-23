
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OngProject.Core.Entities;

namespace PowerAutomate.Core.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(320)")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(64)")]
        [MaxLength(64)]
        public string Password { get; set; }

        // [ForeignKey("Role")]
        // public int RoleId { get; set; }
        // public virtual Role Role { get; set; }
        
    }
}