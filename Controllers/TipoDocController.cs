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
    public class TipoDocController : Controller
    {
        private readonly AlquilautosContext _context;

        public TipoDocController(AlquilautosContext context)
        {
            _context = context;
        }

        // GET: TipoDoc
        public async Task<IActionResult> Index()
        {
              return _context.TipoDoc != null ? 
                          View(await _context.TipoDoc.ToListAsync()) :
                          Problem("Entity set 'AlquilautosContext.TipoDoc'  is null.");
        }

        // GET: TipoDoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDoc == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // GET: TipoDoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tipo")] TipoDoc tipoDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDoc);
        }

        // GET: TipoDoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDoc == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDoc.FindAsync(id);
            if (tipoDoc == null)
            {
                return NotFound();
            }
            return View(tipoDoc);
        }

        // POST: TipoDoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tipo")] TipoDoc tipoDoc)
        {
            if (id != tipoDoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocExists(tipoDoc.Id))
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
            return View(tipoDoc);
        }

        // GET: TipoDoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDoc == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // POST: TipoDoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDoc == null)
            {
                return Problem("Entity set 'AlquilautosContext.TipoDoc'  is null.");
            }
            var tipoDoc = await _context.TipoDoc.FindAsync(id);
            if (tipoDoc != null)
            {
                _context.TipoDoc.Remove(tipoDoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocExists(int id)
        {
          return (_context.TipoDoc?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
