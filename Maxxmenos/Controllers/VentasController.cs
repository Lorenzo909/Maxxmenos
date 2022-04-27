using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Maxxmenos.Models;
using Maxxmenos.Models.Data;

namespace Maxxmenos.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDBContext _context;

        public VentasController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.ventas.Include(v => v.Clientes).Include(v => v.Producto);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.ventas
                .Include(v => v.Clientes)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteCedula"] = new SelectList(_context.clientes, "Cedula", "Cedula");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "IdProducto", "IdProducto");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,ClienteCedula,ProductoId,Fecha")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteCedula"] = new SelectList(_context.clientes, "Cedula", "Cedula", venta.ClienteCedula);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", venta.ProductoId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClienteCedula"] = new SelectList(_context.clientes, "Cedula", "Cedula", venta.ClienteCedula);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", venta.ProductoId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,ClienteCedula,ProductoId,Fecha")] Venta venta)
        {
            if (id != venta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.IdVenta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteCedula"] = new SelectList(_context.clientes, "Cedula", "Cedula", venta.ClienteCedula);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", venta.ProductoId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.ventas
                .Include(v => v.Clientes)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.ventas.FindAsync(id);
            _context.ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.ventas.Any(e => e.IdVenta == id);
        }
    }
}
