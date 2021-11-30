using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoUsuario
    {
        [Required]
        public int codigo { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public string estado { get; set; }
    }
}
