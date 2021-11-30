using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Boleta
    {
        public string codigo { get; set; }
        public string codigoUsuario { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)] public DateTime fechaBoleta { get; set; }
        public Double precioTotal { get; set; }
    }
}
