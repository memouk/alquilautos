using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using alquilautos.Data;
using alquilautos.Models;

namespace alquilautos.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly AlquilautosContext _context;

        public VehiculosController(AlquilautosContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
              return _context.Vehiculos != null ? 
                          View(await _context.Vehiculos.ToListAsync()) :
                          Problem("Entity set 'AlquilautosContext.Vehiculos'  is null.");
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {   
            List<Marcas> marcas = _context.Marcas.ToList();
            ViewBag.marcas = new SelectList(marcas, "Id", "Descripcion");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,creacion,idMarca,idConductor,idPropietario,idTenedor,vencimientoSoat,tipoVehiculo")] Vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculos);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }
            return View(vehiculos);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,creacion,idMarca,idConductor,idPropietario,idTenedor,vencimientoSoat,tipoVehiculo")] Vehiculos vehiculos)
        {
            if (id != vehiculos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosExists(vehiculos.Id))
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
            return View(vehiculos);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'AlquilautosContext.Vehiculos'  is null.");
            }
            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos != null)
            {
                _context.Vehiculos.Remove(vehiculos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosExists(int id)
        {
          return (_context.Vehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
