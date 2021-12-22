using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerAutomate.Core
{
     [Table("DetalleCompra")]
    public partial class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        [Column("IVA", TypeName = "money")]
        public decimal Iva { get; set; }
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        [ForeignKey("IdCompra")]
        [InverseProperty("DetalleCompra")]
        public virtual Compras Compra { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("DetalleCompra")]
        public virtual Productos Producto { get; set; }
    }
}
