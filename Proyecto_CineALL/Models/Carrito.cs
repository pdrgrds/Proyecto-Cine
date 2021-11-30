using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Carrito
    {
        public string codigoProducto { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public int tipo { get; set; }
        [Required]
        public int stock { get; set; }
        [Required]
        public Double precio { get; set; }
        [Required]
        public Double monto { get { return cantidad * precio; } }
        public string rutaimg { get; set; }
    }
}
