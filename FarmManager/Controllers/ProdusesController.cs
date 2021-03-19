using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmManager
{
    [Authorize]
    public class ProdusesController : Controller
    {
        private readonly mngArendaContext _context;

        public ProdusesController(mngArendaContext context)
        {
            _context = context;
        }

        // GET: Produses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produses.ToListAsync());
        }

        // GET: Produses/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // GET: Produses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Produs,PretKg")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produse);
        }

        // GET: Produses/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produses.FindAsync(id);
            if (produse == null)
            {
                return NotFound();
            }
            return View(produse);
        }

        // POST: Produses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Produs,PretKg")] Produse produse)
        {
            if (id != produse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduseExists(produse.Id))
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
            return View(produse);
        }

        // GET: Produses/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // POST: Produses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var produse = await _context.Produses.FindAsync(id);
            _context.Produses.Remove(produse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduseExists(decimal id)
        {
            return _context.Produses.Any(e => e.Id == id);
        }
    }
}