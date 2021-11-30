using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Peliculas
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int idTipo { get; set; }
        public DateTime fechaEstreno { get; set; }
        public DateTime fechaFinal { get; set; }
        public string estado { get; set; }
    }
}
