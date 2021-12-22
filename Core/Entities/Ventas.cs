using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerAutomate.Core
{
     [Table("Ventas")]
    public partial class Ventas
    {
        public Ventas()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }
        [Key]
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        [Required]
        [StringLength(15)]
        public string NumeroFactura { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdCliente")]
        [InverseProperty("Ventas")]
        public virtual Clientes Cliente { get; set; }

        [InverseProperty("Venta")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
