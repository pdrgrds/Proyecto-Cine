using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Boleta
    {
        public string codigo { get; set; }
        public string codigoUsuario { get; set; }
        public DateTime fechaBoleta { get; set; }
        public float precioTotal { get; set; }
    }
}
