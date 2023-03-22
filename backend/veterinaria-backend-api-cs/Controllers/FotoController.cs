/*
 * @fileoverview    {FotoController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Veterinaria.Data;

namespace Veterinaria
{
    public class FotoController : Controller
    {
        private readonly VeterinariaContext _context;

        public FotoController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: Foto
        public async Task<IActionResult> Index()
        {
              return View(await _context.Foto.ToListAsync());
        }

        // GET: Foto/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .FirstOrDefaultAsync(m => m.IntIdFoto == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // GET: Foto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdFoto,StrImagen,IntIdMascota")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foto);
        }

        // GET: Foto/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }
            return View(foto);
        }

        // POST: Foto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdFoto,StrImagen,IntIdMascota")] Foto foto)
        {
            if (id != foto.IntIdFoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoExists(foto.IntIdFoto))
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
            return View(foto);
        }

        // GET: Foto/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .FirstOrDefaultAsync(m => m.IntIdFoto == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Foto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Foto == null)
            {
                return Problem("Entity set 'VeterinariaContext.Foto'  is null.");
            }
            var foto = await _context.Foto.FindAsync(id);
            if (foto != null)
            {
                _context.Foto.Remove(foto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoExists(long? id)
        {
          return _context.Foto.Any(e => e.IntIdFoto == id);
        }
    }
}
