/*
 * @fileoverview    {PersonaController}
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
     * TODO: Description of {@code PersonaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class PersonaController : Controller {
        private readonly VeterinariaContext _context;

        public PersonaController(VeterinariaContext context) {
            _context = context;
        }

        // GET: Persona
        public async Task<IActionResult> Index() {
              return View(await _context.Persona.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Persona == null) {
                return NotFound();
            }

            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.IntIdPersona == id);
            if (persona == null) {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Persona/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdPersona,StrNombres,StrCelular,StrEmail,StrUsuario,StrClave")] Persona persona) {
            if (ModelState.IsValid) {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Persona == null) {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null) {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdPersona,StrNombres,StrCelular,StrEmail,StrUsuario,StrClave")] Persona persona) {
            if (id != persona.IntIdPersona) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!PersonaExists(persona.IntIdPersona)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Persona == null) {
                return NotFound();
            }

            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.IntIdPersona == id);
            if (persona == null) {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Persona == null) {
                return Problem("Entity set 'VeterinariaContext.Persona'  is null.");
            }
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null) {
                _context.Persona.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(long? id) {
          return _context.Persona.Any(e => e.IntIdPersona == id);
        }
    }
}
