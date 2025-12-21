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
    public class WhoController : Controller
    {
        private readonly FinanceNoteContext _context;

        public WhoController(FinanceNoteContext context)
        {
            _context = context;
        }

        // GET: Who
        public async Task<IActionResult> Index()
        {
            return View(await _context.Who.ToListAsync());
        }

        // GET: Who/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var who = await _context.Who
                .FirstOrDefaultAsync(m => m.Id == id);
            if (who == null)
            {
                return NotFound();
            }

            return View(who);
        }

        // GET: Who/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Who/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Event,Cash,Icoca")] Who who)
        {
            if (ModelState.IsValid)
            {
                _context.Add(who);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(who);
        }

        // GET: Who/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var who = await _context.Who.FindAsync(id);
            if (who == null)
            {
                return NotFound();
            }
            return View(who);
        }

        // POST: Who/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Event,Cash,Icoca")] Who who)
        {
            if (id != who.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(who);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhoExists(who.Id))
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
            return View(who);
        }

        // GET: Who/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var who = await _context.Who
                .FirstOrDefaultAsync(m => m.Id == id);
            if (who == null)
            {
                return NotFound();
            }

            return View(who);
        }

        // POST: Who/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var who = await _context.Who.FindAsync(id);
            if (who != null)
            {
                _context.Who.Remove(who);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhoExists(int id)
        {
            return _context.Who.Any(e => e.Id == id);
        }
    }
}
