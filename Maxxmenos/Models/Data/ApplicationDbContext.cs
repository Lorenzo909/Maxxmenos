using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxxmenos.Models.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<Maxxmenos.Models.Categoria> Categoria { get; set; }
        public DbSet<Maxxmenos.Models.Producto> Producto { get; set; }
        public DbSet<Maxxmenos.Models.Proveedor> proveedors { get; set; }
        public DbSet<Maxxmenos.Models.Cliente> clientes { get; set; }
        public DbSet<Maxxmenos.Models.Venta> ventas { get; set; }
    }
}
