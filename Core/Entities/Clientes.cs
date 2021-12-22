using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerAutomate.Core
{
     [Table("Clientes")]
    public partial class Clientes
    {
        public Clientes()
        {
            Ventas = new HashSet<Ventas>();
        }
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Dni es requerido")]
        [Column("DNI")]
        [StringLength(10)]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Correo es requerido")]
        [StringLength(250)]
        [EmailAddress(ErrorMessage="Ingrese un correo válido.")]
        public string Correo { get; set; }

        [InverseProperty("Cliente")]
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
