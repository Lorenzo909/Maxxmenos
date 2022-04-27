using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maxxmenos.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public List<Venta> Ventas { set; get; }
    }
}
