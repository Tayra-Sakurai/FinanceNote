using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanceNote.Data;
using FinanceNote.Models;

namespace FinanceNote.Controllers
{
    public class MachasController : Controller
    {
        private readonly FinanceNoteContext _context;

        public MachasController(FinanceNoteContext context)
        {
            _context = context;
        }

        // GET: Machas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Macha.ToListAsync());
        }

        // GET: Machas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macha = await _context.Macha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (macha == null)
            {
                return NotFound();
            }

            return View(macha);
        }

        // GET: Machas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Title,Cash")] Macha macha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(macha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(macha);
        }

        // GET: Machas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macha = await _context.Macha.FindAsync(id);
            if (macha == null)
            {
                return NotFound();
            }
            return View(macha);
        }

        // POST: Machas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Title,Cash")] Macha macha)
        {
            if (id != macha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(macha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachaExists(macha.Id))
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
            return View(macha);
        }

        // GET: Machas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macha = await _context.Macha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (macha == null)
            {
                return NotFound();
            }

            return View(macha);
        }

        // POST: Machas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var macha = await _context.Macha.FindAsync(id);
            if (macha != null)
            {
                _context.Macha.Remove(macha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachaExists(int id)
        {
            return _context.Macha.Any(e => e.Id == id);
        }
    }
}
