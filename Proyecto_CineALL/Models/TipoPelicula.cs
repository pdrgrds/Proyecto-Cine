using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TipoPelicula
    {
        [Required]
        public int codigo { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public string estado { get; set; }
    }
}
