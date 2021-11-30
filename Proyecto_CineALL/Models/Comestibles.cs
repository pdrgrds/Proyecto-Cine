using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Comestibles
    {
        public string cod_Com { get; set; }
        [Required]
        public string descrip { get; set; }
        [Required]
        public Double precio { get; set; }
        [Required]
        public int stock_Actual { get; set; }
        [Required]
        public int id_Tipo { get; set; }
        [Required]
        public int id_proveedor { get; set; }
        [Required]
        public string estado { get; set; }
        public string rutaimg { get; set; }
        public string descripcionTipo { get; set; }
        public string descripcionProveedor { get; set; }
    }
}
