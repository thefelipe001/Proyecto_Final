using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Producto
    {
        [Key]
        public int codigo { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
    }
}
