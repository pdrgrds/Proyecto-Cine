using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TipoComestible
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string descrip { get; set; }
        [Required]
        public string estado { get; set; }
    }
}
