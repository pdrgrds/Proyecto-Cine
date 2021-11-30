using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DetalleBoleta
    {
        public string codigo { get; set; }
        public string codigoBoleta { get; set; }
        public string codigoPelicula { get; set; }
        public string codigoComestible { get; set; }
        public int cantidad { get; set; }
        public float total { get; set; }
    }
}
