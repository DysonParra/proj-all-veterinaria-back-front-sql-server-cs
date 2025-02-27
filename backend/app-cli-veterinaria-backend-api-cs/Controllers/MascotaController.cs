/*
 * @fileoverview    {MascotaController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
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

namespace Veterinaria {

    /**
     * TODO: Description of {@code MascotaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MascotaController : Controller {
        private readonly VeterinariaContext _context;

        /**
         * TODO: Description of method {@code MascotaController}.
         *
         */
        public MascotaController(VeterinariaContext context) {
            _context = context;
        }

        /**
         * GET: Mascota
         *
         */
        public async Task<IActionResult> Index() {
              return View(await _context.Mascota.ToListAsync());
        }

        /**
         * GET: Mascota/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Mascota == null) {
                return NotFound();
            }

            var mascota = await _context.Mascota
                .FirstOrDefaultAsync(m => m.IntIdMascota == id);
            if (mascota == null) {
                return NotFound();
            }

            return View(mascota);
        }

        /**
         * GET: Mascota/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Mascota/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMascota,StrNombre,StrEdad,StrUbicacion,StrRaza,StrTipo,IntIdPersona")] Mascota mascota) {
            if (ModelState.IsValid) {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        /**
         * GET: Mascota/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Mascota == null) {
                return NotFound();
            }

            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota == null) {
                return NotFound();
            }
            return View(mascota);
        }

        /**
         * POST: Mascota/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMascota,StrNombre,StrEdad,StrUbicacion,StrRaza,StrTipo,IntIdPersona")] Mascota mascota) {
            if (id != mascota.IntIdMascota) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MascotaExists(mascota.IntIdMascota)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        /**
         * GET: Mascota/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Mascota == null) {
                return NotFound();
            }

            var mascota = await _context.Mascota
                .FirstOrDefaultAsync(m => m.IntIdMascota == id);
            if (mascota == null) {
                return NotFound();
            }

            return View(mascota);
        }

        /**
         * POST: Mascota/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Mascota == null) {
                return Problem("Entity set 'VeterinariaContext.Mascota'  is null.");
            }
            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota != null) {
                _context.Mascota.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MascotaExists}.
         *
         */
        private bool MascotaExists(long? id) {
          return _context.Mascota.Any(e => e.IntIdMascota == id);
        }
    }
}
