using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerAutomate.Core
{
     [Table("Proveedores")]
    public partial class Proveedores
    {
        public Proveedores()
        {
            Compras = new HashSet<Compras>();
        }

        [Key]
        public int IdProveedor { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    
        [Required]
        [Column("DNI")]
        [StringLength(17)]
        public string Dni { get; set; }
        [Required]
        [StringLength(250)]
        public string Correo { get; set; }

        [InverseProperty("Proveedor")]
        public virtual ICollection<Compras> Compras { get; set; }
    }
}
