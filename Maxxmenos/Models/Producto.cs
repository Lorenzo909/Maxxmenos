using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maxxmenos.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }


        //Propiedad de navegación
        public Categoria Categoria { get; set; }
        public Proveedor Proveedor { set; get; }

       

    }
}
