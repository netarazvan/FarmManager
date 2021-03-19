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
    public class DefectiuniController : Controller
    {
        private readonly mngArendaContext _context;

        public DefectiuniController(mngArendaContext context)
        {
            _context = context;
        }

        // GET: Defectiuni
        public async Task<IActionResult> Index()
        {
            var mngArendaContext = _context.Defectiunis.Include(d => d.IdUtilajNavigation);
            return View(await mngArendaContext.ToListAsync());
        }

        // GET: Defectiuni/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectiuni = await _context.Defectiunis
                .Include(d => d.IdUtilajNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defectiuni == null)
            {
                return NotFound();
            }

            return View(defectiuni);
        }

        // GET: Defectiuni/Create
        public IActionResult Create()
        {
            ViewData["IdUtilaj"] = new SelectList(_context.Utilajes, "Id", "FullDen");
            return View();
        }

        // POST: Defectiuni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUtilaj,Detalii,CostReparatie,Reparat")] Defectiuni defectiuni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defectiuni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUtilaj"] = new SelectList(_context.Utilajes, "Id", "Marca", defectiuni.IdUtilaj);
            return View(defectiuni);
        }

        // GET: Defectiuni/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectiuni = await _context.Defectiunis.FindAsync(id);
            if (defectiuni == null)
            {
                return NotFound();
            }
            ViewData["IdUtilaj"] = new SelectList(_context.Utilajes, "Id", "FullDen", defectiuni.IdUtilaj);
            return View(defectiuni);
        }

        // POST: Defectiuni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdUtilaj,Detalii,CostReparatie,Reparat")] Defectiuni defectiuni)
        {
            if (id != defectiuni.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defectiuni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefectiuniExists(defectiuni.Id))
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
            ViewData["IdUtilaj"] = new SelectList(_context.Utilajes, "Id", "Marca", defectiuni.IdUtilaj);
            return View(defectiuni);
        }

        // GET: Defectiuni/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectiuni = await _context.Defectiunis
                .Include(d => d.IdUtilajNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defectiuni == null)
            {
                return NotFound();
            }

            return View(defectiuni);
        }

        // POST: Defectiuni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var defectiuni = await _context.Defectiunis.FindAsync(id);
            _context.Defectiunis.Remove(defectiuni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefectiuniExists(decimal id)
        {
            return _context.Defectiunis.Any(e => e.Id == id);
        }
    }
}