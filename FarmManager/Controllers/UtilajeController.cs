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
    public class UtilajeController : Controller
    {
        private readonly mngArendaContext _context;

        public UtilajeController(mngArendaContext context)
        {
            _context = context;
        }

        // GET: Utilaje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilajes.ToListAsync());
        }

        // GET: Utilaje/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilaje = await _context.Utilajes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilaje == null)
            {
                return NotFound();
            }

            return View(utilaje);
        }

        // GET: Utilaje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilaje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tip,Marca,Model,An")] Utilaje utilaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilaje);
        }

        // GET: Utilaje/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilaje = await _context.Utilajes.FindAsync(id);
            if (utilaje == null)
            {
                return NotFound();
            }
            return View(utilaje);
        }

        // POST: Utilaje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Tip,Marca,Model,An")] Utilaje utilaje)
        {
            if (id != utilaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilajeExists(utilaje.Id))
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
            return View(utilaje);
        }

        // GET: Utilaje/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilaje = await _context.Utilajes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilaje == null)
            {
                return NotFound();
            }

            return View(utilaje);
        }

        // POST: Utilaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var utilaje = await _context.Utilajes.FindAsync(id);
            _context.Utilajes.Remove(utilaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilajeExists(decimal id)
        {
            return _context.Utilajes.Any(e => e.Id == id);
        }
    }
}