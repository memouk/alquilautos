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
    public class VehiculosDeportivosController : Controller
    {
        private readonly AlquilautosContext _context;

        public VehiculosDeportivosController(AlquilautosContext context)
        {
            _context = context;
        }

        // GET: VehiculosDeportivos
        public async Task<IActionResult> Index()
        {
              return _context.VehiculosDeportivos != null ? 
                          View(await _context.VehiculosDeportivos.ToListAsync()) :
                          Problem("Entity set 'AlquilautosContext.VehiculosDeportivos'  is null.");
        }

        // GET: VehiculosDeportivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehiculosDeportivos == null)
            {
                return NotFound();
            }

            var vehiculosDeportivos = await _context.VehiculosDeportivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculosDeportivos == null)
            {
                return NotFound();
            }

            return View(vehiculosDeportivos);
        }

        // GET: VehiculosDeportivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculosDeportivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("potMotor,velMax,Id,Placa,creacion,idMarca,idConductor,idPropietario,idTenedor,vencimientoSoat,tipoVehiculo")] VehiculosDeportivos vehiculosDeportivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculosDeportivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculosDeportivos);
        }

        // GET: VehiculosDeportivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehiculosDeportivos == null)
            {
                return NotFound();
            }

            var vehiculosDeportivos = await _context.VehiculosDeportivos.FindAsync(id);
            if (vehiculosDeportivos == null)
            {
                return NotFound();
            }
            return View(vehiculosDeportivos);
        }

        // POST: VehiculosDeportivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("potMotor,velMax,Id,Placa,creacion,idMarca,idConductor,idPropietario,idTenedor,vencimientoSoat,tipoVehiculo")] VehiculosDeportivos vehiculosDeportivos)
        {
            if (id != vehiculosDeportivos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculosDeportivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosDeportivosExists(vehiculosDeportivos.Id))
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
            return View(vehiculosDeportivos);
        }

        // GET: VehiculosDeportivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehiculosDeportivos == null)
            {
                return NotFound();
            }

            var vehiculosDeportivos = await _context.VehiculosDeportivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculosDeportivos == null)
            {
                return NotFound();
            }

            return View(vehiculosDeportivos);
        }

        // POST: VehiculosDeportivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehiculosDeportivos == null)
            {
                return Problem("Entity set 'AlquilautosContext.VehiculosDeportivos'  is null.");
            }
            var vehiculosDeportivos = await _context.VehiculosDeportivos.FindAsync(id);
            if (vehiculosDeportivos != null)
            {
                _context.VehiculosDeportivos.Remove(vehiculosDeportivos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosDeportivosExists(int id)
        {
          return (_context.VehiculosDeportivos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
