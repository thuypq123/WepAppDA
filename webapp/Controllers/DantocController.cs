using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Controllers
{
    public class DantocController : Controller
    {
        private readonly covid19Context _context;

        public DantocController(covid19Context context)
        {
            _context = context;
        }

        // GET: Dantoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dantocs.ToListAsync());
        }

        // GET: Dantoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantocs
                .FirstOrDefaultAsync(m => m.Madt == id);
            if (dantoc == null)
            {
                return NotFound();
            }

            return View(dantoc);
        }

        // GET: Dantoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dantoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madt,Tendt")] Dantoc dantoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dantoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dantoc);
        }

        // GET: Dantoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantocs.FindAsync(id);
            if (dantoc == null)
            {
                return NotFound();
            }
            return View(dantoc);
        }

        // POST: Dantoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madt,Tendt")] Dantoc dantoc)
        {
            if (id != dantoc.Madt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dantoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DantocExists(dantoc.Madt))
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
            return View(dantoc);
        }

        // GET: Dantoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantocs
                .FirstOrDefaultAsync(m => m.Madt == id);
            if (dantoc == null)
            {
                return NotFound();
            }

            return View(dantoc);
        }

        // POST: Dantoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dantoc = await _context.Dantocs.FindAsync(id);
            _context.Dantocs.Remove(dantoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DantocExists(int id)
        {
            return _context.Dantocs.Any(e => e.Madt == id);
        }
    }
}
