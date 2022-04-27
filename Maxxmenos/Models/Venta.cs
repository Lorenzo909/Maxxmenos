using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maxxmenos.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { set; get; }
        public string ClienteCedula { set; get; }
        public int ProductoId { set; get; }
        public DateTime Fecha { set; get; }

        public Cliente Clientes { set; get; }
        public Producto Producto { set; get; }
    }
}
