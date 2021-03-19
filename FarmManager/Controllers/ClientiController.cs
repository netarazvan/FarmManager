using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmManager.Views
{
    [Authorize]
    public class ClientiController : Controller
    {
        private readonly mngArendaContext _context;

        public ClientiController(mngArendaContext context)
        {
            _context = context;
        }

        // GET: Clienti

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientis.ToListAsync());
        }

        // GET: Clienti/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clientis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienti == null)
            {
                return NotFound();
            }
            return View(clienti);
        }

        // GET: Clienti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clienti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Telefon,SuprafataHa")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienti);
        }

        // GET: Clienti/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clientis.FindAsync(id);
            if (clienti == null)
            {
                return NotFound();
            }
            return View(clienti);
        }

        // POST: Clienti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Nume,Telefon,SuprafataHa")] Clienti clienti)
        {
            if (id != clienti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientiExists(clienti.Id))
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
            return View(clienti);
        }

        // GET: Clienti/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clientis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienti == null)
            {
                return NotFound();
            }

            return View(clienti);
        }

        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var clienti = await _context.Clientis.FindAsync(id);
            _context.Clientis.Remove(clienti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientiExists(decimal id)
        {
            return _context.Clientis.Any(e => e.Id == id);
        }
    }
}