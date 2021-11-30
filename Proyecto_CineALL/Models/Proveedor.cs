using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Proveedor
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string estado { get; set; }
    }
}
