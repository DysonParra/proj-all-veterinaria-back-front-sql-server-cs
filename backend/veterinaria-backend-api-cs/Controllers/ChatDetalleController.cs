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
    public class ChatDetalleController : Controller
    {
        private readonly VeterinariaContext _context;

        public ChatDetalleController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: ChatDetalle
        public async Task<IActionResult> Index()
        {
              return View(await _context.ChatDetalle.ToListAsync());
        }

        // GET: ChatDetalle/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ChatDetalle == null)
            {
                return NotFound();
            }

            var chatDetalle = await _context.ChatDetalle
                .FirstOrDefaultAsync(m => m.IntIdChatDetalle == id);
            if (chatDetalle == null)
            {
                return NotFound();
            }

            return View(chatDetalle);
        }

        // GET: ChatDetalle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdChatDetalle,DtUltima,EnmEscribiendo,IntIdPersona")] ChatDetalle chatDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatDetalle);
        }

        // GET: ChatDetalle/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ChatDetalle == null)
            {
                return NotFound();
            }

            var chatDetalle = await _context.ChatDetalle.FindAsync(id);
            if (chatDetalle == null)
            {
                return NotFound();
            }
            return View(chatDetalle);
        }

        // POST: ChatDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdChatDetalle,DtUltima,EnmEscribiendo,IntIdPersona")] ChatDetalle chatDetalle)
        {
            if (id != chatDetalle.IntIdChatDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatDetalleExists(chatDetalle.IntIdChatDetalle))
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
            return View(chatDetalle);
        }

        // GET: ChatDetalle/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ChatDetalle == null)
            {
                return NotFound();
            }

            var chatDetalle = await _context.ChatDetalle
                .FirstOrDefaultAsync(m => m.IntIdChatDetalle == id);
            if (chatDetalle == null)
            {
                return NotFound();
            }

            return View(chatDetalle);
        }

        // POST: ChatDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.ChatDetalle == null)
            {
                return Problem("Entity set 'VeterinariaContext.ChatDetalle'  is null.");
            }
            var chatDetalle = await _context.ChatDetalle.FindAsync(id);
            if (chatDetalle != null)
            {
                _context.ChatDetalle.Remove(chatDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatDetalleExists(long? id)
        {
          return _context.ChatDetalle.Any(e => e.IntIdChatDetalle == id);
        }
    }
}
