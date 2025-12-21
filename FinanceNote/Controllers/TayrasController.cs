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
    public class TayrasController : Controller
    {
        private readonly FinanceNoteContext _context;

        public TayrasController(FinanceNoteContext context)
        {
            _context = context;
        }

        // GET: Tayras
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.Name == "THINKPADX13\\taira")
            {
                return View(await _context.Tayra.ToListAsync());
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: Tayras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tayra = await _context.Tayra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tayra == null)
            {
                return NotFound();
            }

            return View(tayra);
        }

        // GET: Tayras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tayras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Event,Cash,Icoca,Coop")] Tayra tayra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tayra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tayra);
        }

        // GET: Tayras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tayra = await _context.Tayra.FindAsync(id);
            if (tayra == null)
            {
                return NotFound();
            }
            return View(tayra);
        }

        // POST: Tayras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Event,Cash,Icoca,Coop")] Tayra tayra)
        {
            if (id != tayra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tayra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TayraExists(tayra.Id))
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
            return View(tayra);
        }

        // GET: Tayras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tayra = await _context.Tayra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tayra == null)
            {
                return NotFound();
            }

            return View(tayra);
        }

        // POST: Tayras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tayra = await _context.Tayra.FindAsync(id);
            if (tayra != null)
            {
                _context.Tayra.Remove(tayra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TayraExists(int id)
        {
            return _context.Tayra.Any(e => e.Id == id);
        }
    }
}
