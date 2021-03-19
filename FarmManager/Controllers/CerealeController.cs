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
    public class CerealeController : Controller
    {
        private readonly mngArendaContext _context;

        public CerealeController(mngArendaContext context)
        {
            _context = context;
        }

        // GET: Cereale
        public async Task<IActionResult> Index()
        {
            var mngArendaContext = _context.Cereales.Include(c => c.IdProdusNavigation);
            return View(await mngArendaContext.ToListAsync());
        }

        // GET: Cereale/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cereale = await _context.Cereales
                .Include(c => c.IdProdusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cereale == null)
            {
                return NotFound();
            }

            return View(cereale);
        }

        // GET: Cereale/Create
        public IActionResult Create()
        {
            ViewData["IdProdus"] = new SelectList(_context.Produses, "Id", "Produs");
            return View();
        }

        // POST: Cereale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProdus,CantitateTone")] Cereale cereale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cereale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProdus"] = new SelectList(_context.Produses, "Id", "Id", cereale.IdProdus);
            return View(cereale);
        }

        // GET: Cereale/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cereale = await _context.Cereales.FindAsync(id);
            if (cereale == null)
            {
                return NotFound();
            }
            ViewData["IdProdus"] = new SelectList(_context.Produses, "Id", "Produs", cereale.IdProdus);
            return View(cereale);
        }

        // POST: Cereale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdProdus,CantitateTone")] Cereale cereale)
        {
            if (id != cereale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cereale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CerealeExists(cereale.Id))
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
            ViewData["IdProdus"] = new SelectList(_context.Produses, "Id", "Id", cereale.IdProdus);
            return View(cereale);
        }

        // GET: Cereale/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cereale = await _context.Cereales
                .Include(c => c.IdProdusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cereale == null)
            {
                return NotFound();
            }

            return View(cereale);
        }

        // POST: Cereale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var cereale = await _context.Cereales.FindAsync(id);
            _context.Cereales.Remove(cereale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CerealeExists(decimal id)
        {
            return _context.Cereales.Any(e => e.Id == id);
        }
    }
}