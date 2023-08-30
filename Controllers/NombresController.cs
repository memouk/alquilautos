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
    public class NombresController : Controller
    {
        private readonly AlquilautosContext _context;

        public NombresController(AlquilautosContext context)
        {
            _context = context;
        }

        // GET: Nombres
        public async Task<IActionResult> Index()
        {
              return _context.Nombres != null ? 
                          View(await _context.Nombres.ToListAsync()) :
                          Problem("Entity set 'AlquilautosContext.Nombres'  is null.");
        }

        // GET: Nombres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nombres == null)
            {
                return NotFound();
            }

            var nombres = await _context.Nombres
                .FirstOrDefaultAsync(m => m.NombresId == id);
            if (nombres == null)
            {
                return NotFound();
            }

            return View(nombres);
        }

        // GET: Nombres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nombres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombresId,primerNombre,segundoNombre,primerApellido,segundoApellido")] Nombres nombres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nombres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nombres);
        }

        // GET: Nombres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nombres == null)
            {
                return NotFound();
            }

            var nombres = await _context.Nombres.FindAsync(id);
            if (nombres == null)
            {
                return NotFound();
            }
            return View(nombres);
        }

        // POST: Nombres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NombresId,primerNombre,segundoNombre,primerApellido,segundoApellido")] Nombres nombres)
        {
            if (id != nombres.NombresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nombres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NombresExists(nombres.NombresId))
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
            return View(nombres);
        }

        // GET: Nombres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nombres == null)
            {
                return NotFound();
            }

            var nombres = await _context.Nombres
                .FirstOrDefaultAsync(m => m.NombresId == id);
            if (nombres == null)
            {
                return NotFound();
            }

            return View(nombres);
        }

        // POST: Nombres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nombres == null)
            {
                return Problem("Entity set 'AlquilautosContext.Nombres'  is null.");
            }
            var nombres = await _context.Nombres.FindAsync(id);
            if (nombres != null)
            {
                _context.Nombres.Remove(nombres);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NombresExists(int id)
        {
          return (_context.Nombres?.Any(e => e.NombresId == id)).GetValueOrDefault();
        }
    }
}
