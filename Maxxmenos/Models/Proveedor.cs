using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maxxmenos.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Compania { get; set; }
        public string Representante { get; set; }
        public string Telefono { get; set; }
        public string ProductoId { set; get; }

        public Producto Producto { set; get; }
        
    }
}
