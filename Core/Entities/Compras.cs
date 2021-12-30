using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerAutomate.Core
{
    [Table("Compras")]
    public partial class Compras
    {
        public Compras()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
        }
        [Key]
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        
        [Required]
        [StringLength(15)]
        public string NumeroFactura { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdProveedor")]
        [InverseProperty("Compras")]
        public virtual Proveedores Proveedor { get; set; }

        [InverseProperty("Compra")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }
}
