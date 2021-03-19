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
    public class InputuriController : Controller
    {
        private readonly mngArendaContext _context;

        public InputuriController(mngArendaContext context)
        {
            _context = context;
        }

        // GET: Inputuri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inputuris.ToListAsync());
        }

        // GET: Inputuri/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputuri = await _context.Inputuris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inputuri == null)
            {
                return NotFound();
            }

            return View(inputuri);
        }

        // GET: Inputuri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inputuri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tip,Producator,UnitateDeMasura,CantitateUm,PretUm")] Inputuri inputuri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inputuri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inputuri);
        }

        // GET: Inputuri/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputuri = await _context.Inputuris.FindAsync(id);
            if (inputuri == null)
            {
                return NotFound();
            }
            return View(inputuri);
        }

        // POST: Inputuri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Tip,Producator,UnitateDeMasura,CantitateUm,PretUm")] Inputuri inputuri)
        {
            if (id != inputuri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inputuri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InputuriExists(inputuri.Id))
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
            return View(inputuri);
        }

        // GET: Inputuri/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputuri = await _context.Inputuris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inputuri == null)
            {
                return NotFound();
            }

            return View(inputuri);
        }

        // POST: Inputuri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var inputuri = await _context.Inputuris.FindAsync(id);
            _context.Inputuris.Remove(inputuri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InputuriExists(decimal id)
        {
            return _context.Inputuris.Any(e => e.Id == id);
        }
    }
}