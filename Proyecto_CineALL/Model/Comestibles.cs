using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Comestibles
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public float money { get; set; }
        public int stockActual { get; set; }
        public int idTipo { get; set; }
        public int idProveedor { get; set; }
        public string estado { get; set; }
    }
}
