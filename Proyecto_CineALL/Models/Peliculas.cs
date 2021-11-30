using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Peliculas
    {
        public string codigo { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int idTipo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)] public DateTime fechaEstreno { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)] public DateTime fechaFinal { get; set; }
        [Required]
        public Double precio { get; set; }
        [Required]
        public int entradas { get; set; }
        [Required]
        public int entradasRestantes { get; set; }
        [Required]
        public string estado { get; set; }
        public string rutaimg { get; set; }
        public string descripcionTipo { get; set; }
    }
}
